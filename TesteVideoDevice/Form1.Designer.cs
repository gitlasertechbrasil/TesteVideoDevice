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
            this.btnGetImage.Location = new System.Drawing.Point(12, 25);
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.Size = new System.Drawing.Size(75, 23);
            this.btnGetImage.TabIndex = 2;
            this.btnGetImage.Text = "Disparar";
            this.btnGetImage.UseVisualStyleBackColor = true;
            this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 365);
            this.Controls.Add(this.btnGetImage);
            this.Controls.Add(this.pctImage);
            this.Controls.Add(this.tbxSaida);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pctImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSaida;
        private System.Windows.Forms.PictureBox pctImage;
        private System.Windows.Forms.Button btnGetImage;
    }
}

