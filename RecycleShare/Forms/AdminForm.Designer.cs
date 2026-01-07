namespace RecycleShare
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            panel1 = new Panel();
            btnKullanicilar = new Button();
            btnAtiklar = new Button();
            btnIslemler = new Button();
            btnToplama = new Button();
            btnKategori = new Button();
            btnExit = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(btnKullanicilar);
            panel1.Controls.Add(btnAtiklar);
            panel1.Controls.Add(btnIslemler);
            panel1.Controls.Add(btnToplama);
            panel1.Controls.Add(btnKategori);
            panel1.Location = new Point(291, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(303, 410);
            panel1.TabIndex = 0;
            // 
            // btnKullanicilar
            // 
            btnKullanicilar.BackColor = Color.SandyBrown;
            btnKullanicilar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnKullanicilar.Location = new Point(45, 287);
            btnKullanicilar.Name = "btnKullanicilar";
            btnKullanicilar.Size = new Size(211, 46);
            btnKullanicilar.TabIndex = 0;
            btnKullanicilar.Text = "Kullanıcılar";
            btnKullanicilar.UseVisualStyleBackColor = false;
            btnKullanicilar.Click += btnKullanicilar_Click;
            // 
            // btnAtiklar
            // 
            btnAtiklar.BackColor = Color.SandyBrown;
            btnAtiklar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAtiklar.Location = new Point(45, 222);
            btnAtiklar.Name = "btnAtiklar";
            btnAtiklar.Size = new Size(211, 46);
            btnAtiklar.TabIndex = 0;
            btnAtiklar.Text = "Atıklar";
            btnAtiklar.UseVisualStyleBackColor = false;
            btnAtiklar.Click += btnAtiklar_Click;
            // 
            // btnIslemler
            // 
            btnIslemler.BackColor = Color.SandyBrown;
            btnIslemler.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnIslemler.Location = new Point(45, 160);
            btnIslemler.Name = "btnIslemler";
            btnIslemler.Size = new Size(211, 46);
            btnIslemler.TabIndex = 0;
            btnIslemler.Text = "Mevcut İşlemler";
            btnIslemler.UseVisualStyleBackColor = false;
            btnIslemler.Click += btnIslemler_Click;
            // 
            // btnToplama
            // 
            btnToplama.BackColor = Color.SandyBrown;
            btnToplama.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnToplama.Location = new Point(45, 95);
            btnToplama.Name = "btnToplama";
            btnToplama.Size = new Size(211, 46);
            btnToplama.TabIndex = 0;
            btnToplama.Text = "Toplama Noktaları";
            btnToplama.UseVisualStyleBackColor = false;
            btnToplama.Click += btnToplama_Click;
            // 
            // btnKategori
            // 
            btnKategori.BackColor = Color.SandyBrown;
            btnKategori.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnKategori.Location = new Point(45, 30);
            btnKategori.Name = "btnKategori";
            btnKategori.Size = new Size(211, 46);
            btnKategori.TabIndex = 0;
            btnKategori.Text = "Atık Kategorileri";
            btnKategori.UseVisualStyleBackColor = false;
            btnKategori.Click += btnKategori_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Peru;
            btnExit.BackgroundImage = (Image)resources.GetObject("btnExit.BackgroundImage");
            btnExit.BackgroundImageLayout = ImageLayout.Stretch;
            btnExit.Location = new Point(801, 497);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(52, 52);
            btnExit.TabIndex = 8;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(btnExit);
            Controls.Add(panel1);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnKategori;
        private Button btnToplama;
        private Button btnKullanicilar;
        private Button btnAtiklar;
        private Button btnIslemler;
        private Button btnExit;
    }
}