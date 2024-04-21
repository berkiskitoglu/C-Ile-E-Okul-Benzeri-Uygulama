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

namespace AhiUniNot
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=Okul;Integrated Security=True;");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DersAd,Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum from Tbl_Notlar\r\nINNER JOIN Tbl_Dersler ON Tbl_Notlar.DersID=Tbl_Dersler.DersID where OgrID = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            // Ad Soyad Getirme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT OgrAd,OgrSoyad FROM Tbl_Ogrenciler where OgrID=@p2", baglanti);
            komut2.Parameters.AddWithValue("@p2", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while(dr.Read())
            {
                this.Text = dr[0] + " " + dr[1];
            }
            baglanti.Close();
        }
    }
}
