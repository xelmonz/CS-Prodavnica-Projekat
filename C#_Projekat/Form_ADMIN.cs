using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Projekat
{
    public partial class Form_ADMIN : Form
    {
        Baza dbs;
        //ProdavnicaDataSet ds;
        MsSQL_ProdavnicaDataSet ds;
        public Form_ADMIN()
        {
            InitializeComponent();
            //ds = new ProdavnicaDataSet();
            dbs = new Baza();
            ds = new MsSQL_ProdavnicaDataSet();

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_NoviProizvod frm = new Form_NoviProizvod(ds);
            frm.ShowDialog();
            this.Close();
        }

        private void btnRacuni_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Racuni frm = new Form_Racuni(ds);
            frm.ShowDialog();
            this.Close();
        }

        private void btn_Statistika_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Statistika frm = new Form_Statistika();
            frm.ShowDialog();
            this.Close();
        }

        private void Btn_Nazad(object sender, EventArgs e)
        {
            this.Hide();
            Form_Login frm_log = new Form_Login();
            frm_log.ShowDialog();
            this.Close();
        }

        private void btn_izmena_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Izmena_Proizvoda frm_izmena = new Form_Izmena_Proizvoda();
            frm_izmena.ShowDialog();
            this.Close();
        }

        private void btn_izmena_user_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Admin_Korisnik frm_usr = new Form_Admin_Korisnik();
            frm_usr.ShowDialog();
            this.Close();
        }
    }
}
