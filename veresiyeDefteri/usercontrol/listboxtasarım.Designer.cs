namespace veresiyeDefterim.usercontrol
{
    partial class listboxtasarım
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
            this.label_telefon = new System.Windows.Forms.Label();
            this.label_isim = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_telefon
            // 
            this.label_telefon.AutoSize = true;
            this.label_telefon.ForeColor = System.Drawing.Color.White;
            this.label_telefon.Location = new System.Drawing.Point(82, 32);
            this.label_telefon.Name = "label_telefon";
            this.label_telefon.Size = new System.Drawing.Size(38, 15);
            this.label_telefon.TabIndex = 7;
            this.label_telefon.Text = "label2";
            this.label_telefon.Click += new System.EventHandler(this.Panel1_Click);
            this.label_telefon.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.label_telefon.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // label_isim
            // 
            this.label_isim.AutoSize = true;
            this.label_isim.ForeColor = System.Drawing.Color.White;
            this.label_isim.Location = new System.Drawing.Point(82, 7);
            this.label_isim.Name = "label_isim";
            this.label_isim.Size = new System.Drawing.Size(38, 15);
            this.label_isim.TabIndex = 6;
            this.label_isim.Text = "label1";
            this.label_isim.Click += new System.EventHandler(this.Panel1_Click);
            this.label_isim.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.label_isim.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::veresiyeDefterim.Properties.Resources.Ali;
            this.pictureBox1.Location = new System.Drawing.Point(19, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Panel1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 57);
            this.panel1.TabIndex = 8;
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // listboxtasarım
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.label_telefon);
            this.Controls.Add(this.label_isim);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "listboxtasarım";
            this.Size = new System.Drawing.Size(530, 57);
            this.Load += new System.EventHandler(this.listboxtasarım_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_telefon;
        private Label label_isim;
        private PictureBox pictureBox1;
        private Panel panel1;
    }
}
