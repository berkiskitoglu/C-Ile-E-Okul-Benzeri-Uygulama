using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AhiUniNot
{
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=Okul;Integrated Security=True;");

        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        private void BtnAra_Click(object sender, EventArgs e)
        {

            // DataGrid ' de Kolonların Yerlerini Ayarlama
            dataGridView1.DataSource = ds.NotListesi(int.Parse(TxtOgrID.Text));
            dataGridView1.Columns["OgrID"].DisplayIndex = 0;
            dataGridView1.Columns["NotID"].DisplayIndex = 1;
            dataGridView1.Columns["DersAd"].DisplayIndex = 2;
            dataGridView1.Columns["Sinav1"].DisplayIndex = 3;
            dataGridView1.Columns["Sinav2"].DisplayIndex = 4;
            dataGridView1.Columns["Sinav3"].DisplayIndex = 5;
            dataGridView1.Columns["Proje"].DisplayIndex = 6; 
            dataGridView1.Columns["Ortalama"].DisplayIndex = 7; 
            dataGridView1.Columns["Durum"].DisplayIndex = 8; 

        }

        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "DersAd";
            comboBox1.ValueMember = "DersID";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }
        int NotID;
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NotID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtOgrID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }
        
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            int sinav1, sinav2, sinav3, proje;
            double ortalama;
            //string durum;

            sinav1 = Convert.ToInt32(TxtSinav1.Text);
            sinav2 = Convert.ToInt32(TxtSinav2.Text);
            sinav3 = Convert.ToInt32(TxtSinav3.Text);
            proje = Convert.ToInt32(TxtProje.Text);

            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4.0;
            TxtOrtalama.Text = ortalama.ToString();
            if(ortalama >= 60)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
        }
        
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(TxtOgrID.Text),byte.Parse(TxtSinav1.Text), byte.Parse(TxtSinav2.Text),byte.Parse(TxtSinav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text),bool.Parse(TxtDurum.Text), NotID);
        }
    }
}
