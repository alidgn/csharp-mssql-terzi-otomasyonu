namespace terzi
{
    partial class IletisimEkle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IletisimEkle));
            this.telefon_label = new System.Windows.Forms.Label();
            this.eposta_label = new System.Windows.Forms.Label();
            this.telefon_txt = new System.Windows.Forms.TextBox();
            this.eposta_txt = new System.Windows.Forms.TextBox();
            this.iletisimKaydet_btn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // telefon_label
            // 
            this.telefon_label.AutoSize = true;
            this.telefon_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefon_label.Location = new System.Drawing.Point(16, 37);
            this.telefon_label.Name = "telefon_label";
            this.telefon_label.Size = new System.Drawing.Size(70, 20);
            this.telefon_label.TabIndex = 0;
            this.telefon_label.Text = "Telefon :";
            // 
            // eposta_label
            // 
            this.eposta_label.AutoSize = true;
            this.eposta_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eposta_label.Location = new System.Drawing.Point(12, 78);
            this.eposta_label.Name = "eposta_label";
            this.eposta_label.Size = new System.Drawing.Size(74, 20);
            this.eposta_label.TabIndex = 1;
            this.eposta_label.Text = "E-Posta :";
            // 
            // telefon_txt
            // 
            this.telefon_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefon_txt.Location = new System.Drawing.Point(92, 34);
            this.telefon_txt.MaxLength = 11;
            this.telefon_txt.Name = "telefon_txt";
            this.telefon_txt.Size = new System.Drawing.Size(180, 26);
            this.telefon_txt.TabIndex = 0;
            this.telefon_txt.TextChanged += new System.EventHandler(this.telefon_txt_TextChanged);
            this.telefon_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefon_txt_KeyPress);
            // 
            // eposta_txt
            // 
            this.eposta_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eposta_txt.ForeColor = System.Drawing.Color.LightGray;
            this.eposta_txt.Location = new System.Drawing.Point(92, 75);
            this.eposta_txt.Name = "eposta_txt";
            this.eposta_txt.Size = new System.Drawing.Size(180, 26);
            this.eposta_txt.TabIndex = 1;
            this.eposta_txt.Text = "Boş geçilebilir.";
            this.eposta_txt.Enter += new System.EventHandler(this.eposta_txt_Enter);
            this.eposta_txt.Leave += new System.EventHandler(this.eposta_txt_Leave);
            // 
            // iletisimKaydet_btn
            // 
            this.iletisimKaydet_btn.Image = global::terzi.Properties.Resources.kaydet_48;
            this.iletisimKaydet_btn.Location = new System.Drawing.Point(119, 107);
            this.iletisimKaydet_btn.Name = "iletisimKaydet_btn";
            this.iletisimKaydet_btn.Size = new System.Drawing.Size(80, 62);
            this.iletisimKaydet_btn.TabIndex = 4;
            this.iletisimKaydet_btn.UseVisualStyleBackColor = true;
            this.iletisimKaydet_btn.Click += new System.EventHandler(this.iletisimKaydet_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // IletisimEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 181);
            this.Controls.Add(this.iletisimKaydet_btn);
            this.Controls.Add(this.eposta_txt);
            this.Controls.Add(this.telefon_txt);
            this.Controls.Add(this.eposta_label);
            this.Controls.Add(this.telefon_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "IletisimEkle";
            this.Text = "İletişim Bilgisi Ekleme";
            this.Load += new System.EventHandler(this.IletisimEkle_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IletisimEkle_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label telefon_label;
        private System.Windows.Forms.Label eposta_label;
        private System.Windows.Forms.TextBox telefon_txt;
        private System.Windows.Forms.TextBox eposta_txt;
        private System.Windows.Forms.Button iletisimKaydet_btn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}