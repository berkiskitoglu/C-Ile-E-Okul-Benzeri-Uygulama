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

namespace AhiUniNot
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        SqlConnection baglanti = new SqlConnection(@"Data Source=BERK;Initial Catalog=Okul;Integrated Security=True;");

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListele();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Kulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KulupAd";
            comboBox1.ValueMember = "KulupID";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        string c = " ";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListele();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtOgrID.Text = comboBox1.SelectedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtOgrID.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           TxtOgrID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           TxtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           TxtOgrSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            c = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

           if(c == "Kız")
            {
                radioButton1.Checked = true;
            }
           if(c == "Erkek")
            {
                radioButton2.Checked = true;
            }
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtOgrAd.Text, TxtOgrSoyad.Text,byte.Parse(comboBox1.SelectedValue.ToString()),c,int.Parse(TxtOgrID.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
           
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
          
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource =  ds.OgrenciGetir(TxtAra.Text);
        }
    }
}
