﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AhiUniNot
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulupler fr = new FrmKulupler();
            fr.Show();
        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
        }

        private void BtnOgrIsleri_Click(object sender, EventArgs e)
        {
            FrmOgrenci fr = new FrmOgrenci();
            fr.Show();
        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {

        }

        private void BtnSınavNot_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar fr = new FrmSınavNotlar();
            fr.Show();
        }
    }
}
