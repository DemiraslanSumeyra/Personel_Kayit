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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = DESKTOP-PP3S1OU\SQLEXPRESS; Initial Catalog = PersonelVeriTabani; Integrated Security = True");
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            //Toplam personel sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("SELECT COUNT(*) FROM dbo.Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbl_toplampersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //Evli personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM dbo.Tbl_Personel WHERE PersonelDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lbl_evlipersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Bekar personel sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM dbo.Tbl_Personel WHERE PersonelDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lbl_bekarpersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("SELECT COUNT(DISTINCT(PersonelSehir))   FROM dbo.Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lbl_sehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //Toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("SELECT SUM(PersonelMaas)   FROM dbo.Tbl_Personel", baglanti);
            SqlDataReader dr5=komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbl_toplammaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Ortalama maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("SELECT AVG(PersonelMaas)   FROM dbo.Tbl_Personel", baglanti);
            SqlDataReader dr6=komut6.ExecuteReader();
            while (dr6.Read())
            {
                lbl_ortalamamaas.Text = dr6[0].ToString();
            }
            baglanti.Close();

        }
    }
}
