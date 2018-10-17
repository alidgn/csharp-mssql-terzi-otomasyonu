namespace terzi
{
    partial class Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kullaniciAdi_txt = new System.Windows.Forms.TextBox();
            this.sifre_txt = new System.Windows.Forms.TextBox();
            this.kullaniciAdi_label = new System.Windows.Forms.Label();
            this.sifre_label = new System.Windows.Forms.Label();
            this.giris_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "TERZİ YÖNETİM SİSTEMİ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sisteme Giriş";
            // 
            // kullaniciAdi_txt
            // 
            this.kullaniciAdi_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kullaniciAdi_txt.Location = new System.Drawing.Point(137, 140);
            this.kullaniciAdi_txt.Name = "kullaniciAdi_txt";
            this.kullaniciAdi_txt.Size = new System.Drawing.Size(144, 24);
            this.kullaniciAdi_txt.TabIndex = 0;
            // 
            // sifre_txt
            // 
            this.sifre_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sifre_txt.Location = new System.Drawing.Point(137, 185);
            this.sifre_txt.Name = "sifre_txt";
            this.sifre_txt.Size = new System.Drawing.Size(144, 24);
            this.sifre_txt.TabIndex = 1;
            this.sifre_txt.UseSystemPasswordChar = true;
            // 
            // kullaniciAdi_label
            // 
            this.kullaniciAdi_label.AutoSize = true;
            this.kullaniciAdi_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kullaniciAdi_label.Location = new System.Drawing.Point(28, 144);
            this.kullaniciAdi_label.Name = "kullaniciAdi_label";
            this.kullaniciAdi_label.Size = new System.Drawing.Size(101, 20);
            this.kullaniciAdi_label.TabIndex = 4;
            this.kullaniciAdi_label.Text = "Kullanıcı Adı :";
            // 
            // sifre_label
            // 
            this.sifre_label.AutoSize = true;
            this.sifre_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sifre_label.Location = new System.Drawing.Point(79, 189);
            this.sifre_label.Name = "sifre_label";
            this.sifre_label.Size = new System.Drawing.Size(50, 20);
            this.sifre_label.TabIndex = 5;
            this.sifre_label.Text = "Şifre :";
            // 
            // giris_btn
            // 
            this.giris_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("giris_btn.BackgroundImage")));
            this.giris_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.giris_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giris_btn.Location = new System.Drawing.Point(161, 225);
            this.giris_btn.Name = "giris_btn";
            this.giris_btn.Size = new System.Drawing.Size(95, 70);
            this.giris_btn.TabIndex = 2;
            this.giris_btn.UseVisualStyleBackColor = true;
            this.giris_btn.Click += new System.EventHandler(this.giris_btn_Click);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 307);
            this.Controls.Add(this.giris_btn);
            this.Controls.Add(this.sifre_label);
            this.Controls.Add(this.kullaniciAdi_label);
            this.Controls.Add(this.sifre_txt);
            this.Controls.Add(this.kullaniciAdi_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Giris";
            this.Text = "GİRİŞ";
            this.Load += new System.EventHandler(this.Giris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kullaniciAdi_txt;
        private System.Windows.Forms.TextBox sifre_txt;
        private System.Windows.Forms.Label kullaniciAdi_label;
        private System.Windows.Forms.Label sifre_label;
        private System.Windows.Forms.Button giris_btn;
    }
}