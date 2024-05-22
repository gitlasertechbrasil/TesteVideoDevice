namespace TesteVideoDevice
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxSaida = new System.Windows.Forms.TextBox();
            this.pctImage = new System.Windows.Forms.PictureBox();
            this.btnGetImage = new System.Windows.Forms.Button();
            this.tbxIpCamera = new System.Windows.Forms.TextBox();
            this.tbxIpServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblStatusCamera = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxSaida
            // 
            this.tbxSaida.Location = new System.Drawing.Point(12, 66);
            this.tbxSaida.Multiline = true;
            this.tbxSaida.Name = "tbxSaida";
            this.tbxSaida.Size = new System.Drawing.Size(417, 289);
            this.tbxSaida.TabIndex = 0;
            // 
            // pctImage
            // 
            this.pctImage.Location = new System.Drawing.Point(435, 66);
            this.pctImage.Name = "pctImage";
            this.pctImage.Size = new System.Drawing.Size(353, 289);
            this.pctImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctImage.TabIndex = 1;
            this.pctImage.TabStop = false;
            // 
            // btnGetImage
            // 
            this.btnGetImage.Enabled = false;
            this.btnGetImage.Location = new System.Drawing.Point(713, 21);
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.Size = new System.Drawing.Size(75, 23);
            this.btnGetImage.TabIndex = 2;
            this.btnGetImage.Text = "Disparar";
            this.btnGetImage.UseVisualStyleBackColor = true;
            this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
            // 
            // tbxIpCamera
            // 
            this.tbxIpCamera.Location = new System.Drawing.Point(92, 6);
            this.tbxIpCamera.Name = "tbxIpCamera";
            this.tbxIpCamera.Size = new System.Drawing.Size(140, 20);
            this.tbxIpCamera.TabIndex = 3;
            this.tbxIpCamera.Text = "192.168.50.172";
            // 
            // tbxIpServer
            // 
            this.tbxIpServer.Location = new System.Drawing.Point(92, 32);
            this.tbxIpServer.Name = "tbxIpServer";
            this.tbxIpServer.Size = new System.Drawing.Size(140, 20);
            this.tbxIpServer.TabIndex = 4;
            this.tbxIpServer.Text = "127.0.0.1:51000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP da Câmera:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "IP do Servidor:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(238, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblStatusCamera
            // 
            this.lblStatusCamera.Location = new System.Drawing.Point(319, 9);
            this.lblStatusCamera.Name = "lblStatusCamera";
            this.lblStatusCamera.Size = new System.Drawing.Size(96, 13);
            this.lblStatusCamera.TabIndex = 8;
            this.lblStatusCamera.Text = "Desconectada";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 365);
            this.Controls.Add(this.lblStatusCamera);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxIpServer);
            this.Controls.Add(this.tbxIpCamera);
            this.Controls.Add(this.btnGetImage);
            this.Controls.Add(this.pctImage);
            this.Controls.Add(this.tbxSaida);
            this.Name = "Form1";
            this.Text = "Trigger";
            ((System.ComponentModel.ISupportInitialize)(this.pctImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSaida;
        private System.Windows.Forms.PictureBox pctImage;
        private System.Windows.Forms.Button btnGetImage;
        private System.Windows.Forms.TextBox tbxIpCamera;
        private System.Windows.Forms.TextBox tbxIpServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblStatusCamera;
    }
}

