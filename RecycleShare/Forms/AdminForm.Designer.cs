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
            panel1 = new Panel();
            btnKullanicilar = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            btnKategori = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(btnKullanicilar);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
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
            btnKullanicilar.Click += button2_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.SandyBrown;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button4.Location = new Point(45, 222);
            button4.Name = "button4";
            button4.Size = new Size(211, 46);
            button4.TabIndex = 0;
            button4.Text = "Atıklar";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.SandyBrown;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.Location = new Point(45, 160);
            button3.Name = "button3";
            button3.Size = new Size(211, 46);
            button3.TabIndex = 0;
            button3.Text = "Mevcut İşlemler";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button2_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.SandyBrown;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.Location = new Point(45, 95);
            button2.Name = "button2";
            button2.Size = new Size(211, 46);
            button2.TabIndex = 0;
            button2.Text = "Toplama Noktaları";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
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
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(panel1);
            Name = "AdminForm";
            Text = "AdminForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnKategori;
        private Button button2;
        private Button btnKullanicilar;
        private Button button4;
        private Button button3;
    }
}