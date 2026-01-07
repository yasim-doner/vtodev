using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecycleShare.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // ComboBox varsayılan olarak "Kullanıcı" seçili gelsin
            cmbRol.SelectedIndex = 0;

            // Şifre kutusunu güvenli yapalım
            txtSifre.PasswordChar = '*';
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. Boşluk Kontrolü
            if (string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Rol Belirleme (Arayüzdeki seçimi veritabanı koduna çeviriyoruz)
            string secilenRol = "";
            if (cmbRol.SelectedIndex == 0)
            {
                secilenRol = "user"; // Veritabanındaki karşılığı
            }
            else
            {
                secilenRol = "toplayici"; // Veritabanındaki karşılığı
            }

            // 3. Veritabanına Kayıt
            DatabaseHelper db = new DatabaseHelper();
            bool basarili = db.RegisterUser(txtAd.Text, txtSoyad.Text, txtEmail.Text, txtSifre.Text, secilenRol);

            if (basarili)
            {
                MessageBox.Show("Kayıt başarıyla oluşturuldu! Şimdi giriş yapabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Formu kapat, Login ekranına dön
            }
        }
    }
}
