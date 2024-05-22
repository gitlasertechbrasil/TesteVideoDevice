using br.com.ltb.Camera.Pumatronix;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static br.com.ltb.Camera.Pumatronix.Pumatronix;
using System.Threading;

namespace TesteVideoDevice
{
    public partial class Form1 : Form
    {

        private Pumatronix _camera;
        private int imageNumber = 1;
        private Status _statusCamera = Status.Desconectada;

        public Form1()
        {
            InitializeComponent();            
        }

        private void btnGetImage_Click(object sender, EventArgs e)
        {
            var desired = new List<ImageField.TypeOfField>() { ImageField.TypeOfField.Horario };

            try
            {
                var img = _camera.GetImage(80, desired);
                var now = DateTime.Now;

                TriggerInfo inf = new TriggerInfo()
                {
                    CameraDateTime = img.SortedFields[ImageField.TypeOfField.Horario],
                    SystemDateTime = now.ToString("dd/MM/yyyy HH:mm:ss"),
                    ImageName = now.ToString("yyyyMMddHHmmss") + "-" + imageNumber
                };

                imageNumber++;

                var format = new JsonSerializerSettings();
                format.Formatting = Formatting.Indented;
                string serialized = JsonConvert.SerializeObject(inf, format);
                tbxSaida.Text = serialized;

                pctImage.Image = img.Image;

                try
                {
                    sendJson(serialized);
                }
                catch (Exception ex2)
                {
                    throw new Exception("Erro a enviar o trigger para o servidor! Msg: " + ex2.InnerException.Message);
                }
                
            }
            catch (Exception ex)
            {
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(this, ex.Message);
                    });
                }
            }                        
        }

        private void sendJson(string message)
        {
            Uri address;
            address = new Uri($"http://{tbxIpServer.Text}"); //127.0.0.1:51000

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = address;
                    client.Timeout = new TimeSpan(0, 0, 4);
                    var content = new StringContent(message);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var response = client.PostAsync(string.Empty, content).Result;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {                       
                        throw new Exception($"Fail to send, status code: {response.StatusCode}");
                    }
                    else
                    {
                        if(IsHandleCreated)
                        {
                            this.Invoke((MethodInvoker) delegate
                            {
                                tbxSaida.Text += $"\r\n{response.Content}";
                            });
                        }                        
                    }                    
                }
            }
            catch (Exception ex)
            {              
                throw ex.InnerException;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_statusCamera == Status.Desconectada)
            {
                if (string.IsNullOrEmpty(tbxIpCamera.Text))
                {
                    if (IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show(this, "Digite o IP da Câmera!");
                        });
                    }

                    return;
                }

                try
                {
                    _camera = new Pumatronix(tbxIpCamera.Text);
                    _camera.CgiPort = 80;
                    _camera.cameraconnection += _camera_cameraconnection;
                    _camera.OpenAsync();
                }
                catch (Exception ex)
                {
                    _statusCamera = Status.Desconectada;
                    _camera.cameraconnection -= _camera_cameraconnection;

                    if (IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show(this, "Falha ao conectar com a câmera! Msg: " + ex.Message);
                        });
                    }
                }
            }
            else
            {
                try
                {
                    _camera.Close();

                    if (IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {                            
                            btnGetImage.Enabled = false;
                        });
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private void _camera_cameraconnection(object sender, Status connection_status)
        {
            _statusCamera = connection_status;

            if (IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblStatusCamera.Text = connection_status.ToString();

                    if (_statusCamera == Status.Conectada)
                    {
                        btnGetImage.Enabled = true;
                        btnConnect.Text = "Desconectar";
                        ThreadPool.QueueUserWorkItem(SendUrlDataHora);
                    }
                    else
                    {
                        btnGetImage.Enabled = false;
                        btnConnect.Text = "Conectar";
                    }
                });
            }            
        }

        private void SendUrlDataHora(object state)
        {
            try
            {
                string url = $"http://{tbxIpCamera.Text}/api/config.cgi?Data=" +
                    $"{DateTime.Now.Day.ToString().PadLeft(2, '0')}{DateTime.Now.Month.ToString().PadLeft(2, '0')}{DateTime.Now.Year.ToString().Substring(2)}&" +
                    $"Hora={DateTime.Now.Hour.ToString().PadLeft(2, '0')}{DateTime.Now.Minute.ToString().PadLeft(2, '0')}{DateTime.Now.Second.ToString().PadLeft(2, '0')}&" +
                    $"HorarioVerao=0";

                _camera.SendURL(url);
            }
            catch (Exception ex)
            {
                if(IsHandleCreated)
                {
                    MessageBox.Show(this, $"Falha ao altera a data/hora da câmera! MSG: {ex.Message}");
                }
            }
            
        }
    }

    public class TriggerInfo
    {
        public string CameraDateTime { get; set; }
        public string SystemDateTime { get; set; }
        public string ImageName { get; set; } 
    }
}
