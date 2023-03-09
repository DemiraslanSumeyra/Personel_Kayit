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
namespace Personel_Kayit
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = localhost; Initial Catalog = PersonelVeriTabani; Integrated Security = True");

        void Temizle()
        {
            txt_personelID.Text = "";
            txt_personelAd.Text = "";
            txt_personelSoyad.Text = "";
            txt_personelMeslek.Text = "";
            mtb_personelMaas.Text = "";
            cmb_personelSehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txt_personelAd.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO dbo.Tbl_Personel   (PersonelAd,   PersonelSoyad,PersonelSehir,PersonelMaas,PersonelMeslek,PersonelDurum)  VALUES(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_personelAd.Text);
            komut.Parameters.AddWithValue("@p2", txt_personelSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmb_personelSehir.Text);
            komut.Parameters.AddWithValue("@p4", mtb_personelMaas.Text);
            komut.Parameters.AddWithValue("@p5", txt_personelMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi.");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }

        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txt_personelID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_personelAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_personelSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmb_personelSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mtb_personelMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txt_personelMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();


        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("delete from Tbl_Personel where PersonelID=@k1", baglanti);
            komutSil.Parameters.AddWithValue("@k1", txt_personelID.Text);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi.");
        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("update Tbl_Personel set PersonelAd=@a1,PersonelSoyad=@a2,PersonelSehir=@a3,PersonelMaas=@a4,PersonelDurum=@a5,PersonelMeslek=@a6 where PersonelID=@a7", baglanti);
            komutGuncelle.Parameters.AddWithValue("@a1", txt_personelAd.Text);
            komutGuncelle.Parameters.AddWithValue("@a2",txt_personelSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@a3", cmb_personelSehir.Text);
            komutGuncelle.Parameters.AddWithValue("@a4", mtb_personelMaas.Text);
            komutGuncelle.Parameters.AddWithValue("@a5",label8.Text);
            komutGuncelle.Parameters.AddWithValue("@a6",txt_personelMeslek.Text);
            komutGuncelle.Parameters.AddWithValue("@a7", txt_personelID.Text);
            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgileri Güncellendi.");
        }

        private void btn_istatistik_Click(object sender, EventArgs e)
        {
            FrmIstatistik fr = new FrmIstatistik();
            fr.Show();

        }

        private void btn_grafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }
    }
}
