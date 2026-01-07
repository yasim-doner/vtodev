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
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
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
    }
}