using RecycleShare.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecycleShare
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            KategoriYonetimForm kategoriSayfasi = new KategoriYonetimForm();
            kategoriSayfasi.ShowDialog();
        }
        private void btnToplama_Click(object sender, EventArgs e)
        {
            ToplamaYonetimForm toplamaSayfasi = new ToplamaYonetimForm();
            toplamaSayfasi.ShowDialog();
        }
        private void btnKullanicilar_Click(object sender, EventArgs e)
        {
            KullaniciYonetimForm toplamaSayfasi = new KullaniciYonetimForm();
            toplamaSayfasi.ShowDialog();
        }
        private void btnAtiklar_Click(object sender, EventArgs e)
        {
            AtikYonetimForm toplamaSayfasi = new AtikYonetimForm();
            toplamaSayfasi.ShowDialog();
        }

        private void btnIslemler_Click(object sender, EventArgs e)
        {
            IslemYonetimForm IslemSayfasi = new IslemYonetimForm();
            IslemSayfasi.ShowDialog();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
