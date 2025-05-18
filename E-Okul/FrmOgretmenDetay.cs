using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace E_Okul
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-JQ02U7VO;Initial Catalog=DbNotKayit;Integrated Security=True");


        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackColor = Color.Red;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into Tbl_Ders (OgrNumara,OgrAd,OgrSoyad) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", MskNumara.Text);
            komut.Parameters.AddWithValue("@p2", TxtAd.Text);
            komut.Parameters.AddWithValue("@p3", TxtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci sisteme eklendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tbl_DersTableAdapter.Fill(this.dbNotKayitDataSet.Tbl_Ders);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtSinav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            MskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            LblOrtalama.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string durum;
            double ortalama, s1, s2, s3;
            s1 = Convert.ToDouble(TxtSinav1.Text);
            s2 = Convert.ToDouble(TxtSinav2.Text);
            s3 = Convert.ToDouble(TxtSinav3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            LblOrtalama.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "True";

            }
            else
            {
                durum = "False";

            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update Tbl_Ders set OgrS1 = @p1,OgrS2 = @p2,OgrS3 = @p3,Ortalama = @p4,Durum = @p5 where OgrNumara = @p6", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtSinav1.Text);
            komut.Parameters.AddWithValue("@p2", TxtSinav2.Text);
            komut.Parameters.AddWithValue("@p3", TxtSinav3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(LblOrtalama.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", MskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci notları güncellendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tbl_DersTableAdapter.Fill(this.dbNotKayitDataSet.Tbl_Ders);


        }
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {

            this.tbl_DersTableAdapter.Fill(this.dbNotKayitDataSet.Tbl_Ders);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Count(Durum) From Tbl_Ders where Durum = 'True'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblGecenSayisi.Text = dr[0].ToString();
            }
            baglanti.Close();


            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(Durum) From Tbl_Ders where Durum = 'False'", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblKalanSayisi.Text = dr2[0].ToString();
            }
            baglanti.Close();
        }
    }
}
