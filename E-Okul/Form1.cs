using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Okul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackColor = Color.Red;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult cikis = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgrenciGiris frogr = new FrmOgrenciGiris();
            frogr.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmenDetay fr = new FrmOgretmenDetay();
            fr.Show();
        }
    }
}
