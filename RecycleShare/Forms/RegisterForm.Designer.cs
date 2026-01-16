namespace RecycleShare.Forms
{
    partial class RegisterForm
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
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtEmail = new TextBox();
            txtSifre = new TextBox();
            cmbRol = new ComboBox();
            btnKaydet = new Button();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtAd
            // 
            txtAd.Location = new Point(335, 92);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(245, 23);
            txtAd.TabIndex = 0;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(335, 133);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(245, 23);
            txtSoyad.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(335, 176);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(245, 23);
            txtEmail.TabIndex = 0;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(335, 222);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(245, 23);
            txtSifre.TabIndex = 0;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Kullanıcı (Atık Vereceğim)", "Toplayıcı (Atık Toplayacağım)" });
            cmbRol.Location = new Point(335, 267);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(245, 23);
            cmbRol.TabIndex = 1;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(388, 335);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(133, 44);
            btnKaydet.TabIndex = 2;
            btnKaydet.Text = "Sign in";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(275, 95);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 11;
            label3.Text = "Ad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(275, 136);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 12;
            label1.Text = "Soyad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(275, 179);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 13;
            label2.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(275, 225);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 14;
            label4.Text = "Şifre";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(275, 270);
            label5.Name = "label5";
            label5.Size = new Size(25, 15);
            label5.TabIndex = 15;
            label5.Text = "Rol";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(btnKaydet);
            Controls.Add(cmbRol);
            Controls.Add(txtSifre);
            Controls.Add(txtEmail);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtEmail;
        private TextBox txtSifre;
        private ComboBox cmbRol;
        private Button btnKaydet;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
    }
}