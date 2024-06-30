namespace veresiyeDefterim.usercontrol
{
    partial class listboxtasarımborç
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_durum = new System.Windows.Forms.Label();
            this.label_miktar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_açıklama = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_durum
            // 
            this.label_durum.AutoSize = true;
            this.label_durum.ForeColor = System.Drawing.Color.White;
            this.label_durum.Location = new System.Drawing.Point(82, 32);
            this.label_durum.Name = "label_durum";
            this.label_durum.Size = new System.Drawing.Size(38, 15);
            this.label_durum.TabIndex = 11;
            this.label_durum.Text = "label2";
            this.label_durum.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.label_durum.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // label_miktar
            // 
            this.label_miktar.ForeColor = System.Drawing.Color.White;
            this.label_miktar.Location = new System.Drawing.Point(82, 7);
            this.label_miktar.Name = "label_miktar";
            this.label_miktar.Size = new System.Drawing.Size(136, 15);
            this.label_miktar.TabIndex = 10;
            this.label_miktar.Text = "label1";
            this.label_miktar.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.label_miktar.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::veresiyeDefterim.Properties.Resources.Ali;
            this.pictureBox1.Location = new System.Drawing.Point(19, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_açıklama);
            this.panel1.Controls.Add(this.label_durum);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 57);
            this.panel1.TabIndex = 12;
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // label_açıklama
            // 
            this.label_açıklama.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_açıklama.ForeColor = System.Drawing.Color.White;
            this.label_açıklama.Location = new System.Drawing.Point(253, 7);
            this.label_açıklama.Name = "label_açıklama";
            this.label_açıklama.Size = new System.Drawing.Size(265, 40);
            this.label_açıklama.TabIndex = 13;
            this.label_açıklama.Text = "label1";
            this.label_açıklama.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.label_açıklama.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // listboxtasarımborç
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_miktar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "listboxtasarımborç";
            this.Size = new System.Drawing.Size(530, 57);
            this.Load += new System.EventHandler(this.listboxtasarımborç_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label_durum;
        private Label label_miktar;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label_açıklama;
    }
}
