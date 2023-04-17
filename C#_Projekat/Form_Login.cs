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
using System.Data.OleDb;
using System.Data.Sql;

namespace CS_Projekat
{
    public partial class Form_Login : Form
    {
        Baza dbs;
        public Form_Login()
        {
            InitializeComponent();
            dbs = new Baza();                    
        }

        //Belezenje logovanog korisnika
        public static string user_email = "";
        public static string user_password = "";
        public static string id = "";

        private void btn_prijava_Click(object sender, EventArgs e)
        {
            try
            {
                dbs.otvoriKonekciju();

                if (string.IsNullOrEmpty(txt_email.Text.Trim()))
                {
                    errorProvider1.SetError(txt_email, "Email je obavezan!");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txt_email, string.Empty);
                }

                if (string.IsNullOrEmpty(txt_lozinka.Text.Trim()))
                {
                    errorProvider2.SetError(txt_lozinka, "Lozinka je obavezna!");
                    return;
                }
                else
                {
                    errorProvider2.SetError(txt_lozinka, string.Empty);
                }

                String email = txt_email.Text;
                String lozinka = txt_lozinka.Text;            
                //NEPOTREBNO
                user_email = email;
                user_password = lozinka;


                MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter korisnik = new MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
                MsSQL_ProdavnicaDataSet.korisniciDataTable dt = korisnik.GetDataBy_Kupac(email, lozinka);

                MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter admin = new MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
                MsSQL_ProdavnicaDataSet.korisniciDataTable dta = admin.GetDataBy_Admin(email, lozinka); 

                //Pokusaj dobijanja ID
                SqlCommand cmd_get = new SqlCommand();
                cmd_get.Connection = dbs.Konekcija;
                cmd_get.CommandText = @"Select id from korisnici where email='" + email + "' and lozinka='" + lozinka + "' ";

                object i = cmd_get.ExecuteScalar();
                if (i != null)
                {
                    id = i.ToString();
                }

                if (dta.Rows.Count>0)
                {
                    // MessageBox.Show("Uspesna prijava admin!");    
                    this.Hide();
                    Form_ADMIN fm = new Form_ADMIN();
                    fm.ShowDialog();
                    this.Close();
                }
                else if (dt.Rows.Count > 0)
                {
                    // MessageBox.Show("uspesna prijava korisnik!");
                    this.Hide();
                    Form1 fm = new Form1();
                    fm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Korisnik nije registrovan!");
                }
                //Txt reset
                txt_email.Text = "";
                txt_lozinka.Text = "";
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

        private void btn_registracija_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Registracija frm_reg= new Form_Registracija();
            frm_reg.ShowDialog();
            this.Close();    
        }

        private void Enter_prijava(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btn_prijava.PerformClick();
            }
        }
    }
}
