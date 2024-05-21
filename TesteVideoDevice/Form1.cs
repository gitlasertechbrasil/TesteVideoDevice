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

namespace TesteVideoDevice
{
    public partial class Form1 : Form
    {

        private Pumatronix _camera;
        private int imageNumber = 1;

        public Form1()
        {
            InitializeComponent();
            _camera = new Pumatronix("192.168.50.172");
            _camera.Open();
        }

        private void btnGetImage_Click(object sender, EventArgs e)
        {
            var desired = new List<ImageField.TypeOfField>() { ImageField.TypeOfField.Horario };
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
            string serialized = JsonConvert.SerializeObject(inf,format);
            tbxSaida.Text = serialized;

            pctImage.Image = img.Image;
            sendJson(serialized);
        }

        private void sendJson(string message)
        {
            Uri address;
            address = new Uri("http://127.0.0.1:51000");
           
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = address;
                    client.Timeout = new TimeSpan(0, 0, 5000);
                    var content = new StringContent(message);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var response = client.PostAsync(string.Empty, content).Result;


                    if (response.StatusCode != HttpStatusCode.OK)
                    {                       
                        throw new Exception($"Fail to send, status code: {response.StatusCode}");
                    }
                    else
                    {
                       
                    }

                    
                }
            }
            catch (Exception ex)
            {
              
                throw;
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
