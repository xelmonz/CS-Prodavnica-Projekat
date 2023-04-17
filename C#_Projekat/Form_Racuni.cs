using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CS_Projekat
{
    public partial class Form_Racuni : Form
    {
        Baza dbs;
        MsSQL_ProdavnicaDataSet ds;
        MsSQL_ProdavnicaDataSetTableAdapters.racunTableAdapter rAdapter;
        public Form_Racuni()
        {
            InitializeComponent();
            dbs = new Baza();
            ds = new MsSQL_ProdavnicaDataSet();
            rAdapter = new MsSQL_ProdavnicaDataSetTableAdapters.racunTableAdapter();
        }

        public Form_Racuni(MsSQL_ProdavnicaDataSet ds) : this()
        {
            this.ds = ds;
        }


        private void btnPrikazi_Click(object sender, EventArgs e)
        {
            var linq= from x in ds.racun
                      where (x.datum >= dateTimePicker1.Value.Date && x.datum <= dateTimePicker2.Value.Date)
                      select x;

            if (dateTimePicker1.Value > dateTimePicker2.Value)
                {
                MessageBox.Show("Izaberite validne datume!");
                }
            else if (linq.Any()) 
                {
                    dataGridView2.DataSource = linq.CopyToDataTable();
                    //dataGridView2.Columns["vreme"].DefaultCellStyle.Format = "hh:mm:ss";
                }
            else
            {
                MessageBox.Show("Ne postoje računi za izabrani period");
            }
          
        }

        private void Form_Racuni_Load(object sender, EventArgs e)
        {
            rAdapter.Fill(ds.racun);
            dataGridView2.DataSource = ds.racun;

            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;


            MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter user = new MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
            MsSQL_ProdavnicaDataSet.korisniciDataTable korisnici = user.GetKorisnici();

            cb_korisnik.DataSource = korisnici;
            cb_korisnik.DisplayMember = "email";
            cb_korisnik.SelectedIndex = -1;
        }

        private void btn_nazad_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ADMIN frm_admin = new Form_ADMIN();
            frm_admin.ShowDialog();
            this.Close();
        }

        private void btn_korisnik_Click(object sender, EventArgs e)
        {
            try
            {
                dbs.otvoriKonekciju();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbs.Konekcija;
                DataTable dt = new DataTable();

                cmd.CommandText = @"Select * from racun where id in(select id from racun where id_korisnika =(select id from korisnici where email='"+cb_korisnik.Text+"'))";
                SqlDataReader d_reader = cmd.ExecuteReader();
                dt.Load(d_reader);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbs.zatvoriKonekciju();
            }
        }
    }
}
