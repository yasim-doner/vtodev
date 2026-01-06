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
    }
}
