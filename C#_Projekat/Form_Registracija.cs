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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace CS_Projekat
{
    public partial class Form_Registracija : Form
    {
        Baza dbs;

        public Form_Registracija()
        {
            InitializeComponent();
            dbs = new Baza();
        }


        //ako id ne bude AUTO 
        //static public int novi_Id()
        //{
        //    Random rand = new Random(Guid.NewGuid().GetHashCode());
        //    int id = rand.Next();
        //    return id;
        //}

        private void btn_registracija_Click(object sender, EventArgs e)
        {
            String mail = txtEmail.Text;
            //int id=novi_Id();

            try
            {
                dbs.otvoriKonekciju();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbs.Konekcija;
                //_______________________________

                cmd.CommandText = @"INSERT INTO Korisnici(ime,prezime,email,lozinka,vrsta_korisnika)
                    values(@ime,@prezime,@email,@lozinka,@vrsta)";

                //Unos IME
                if (string.IsNullOrEmpty(txtIme.Text.Trim())) {
                    errorProvider1.SetError(txtIme, "Unesite ime");
                    return;
                }
                else {
                    errorProvider1.SetError(txtIme, string.Empty);
                    cmd.Parameters.AddWithValue("ime", txtIme.Text);
                }

                //Unos PREZIME
                if (string.IsNullOrEmpty(txtPrezime.Text.Trim()))
                {
                    errorProvider2.SetError(txtPrezime, "Unesite prezime");
                    return;
                }
                else
                {
                    errorProvider2.SetError(txtPrezime, string.Empty);
                    cmd.Parameters.AddWithValue("prezime", txtPrezime.Text);
                }

                //Unos EMAIL
                MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter email = new MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
                MsSQL_ProdavnicaDataSet.korisniciDataTable dt_mail = email.GetDataBy_Email(txtEmail.Text);

                if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    errorProvider3.SetError(txtEmail, "Unesite Email");
                    return;
                }
                else if (dt_mail.Rows.Count > 0)
                {
                    errorProvider3.SetError(txtEmail, "Email je već registrovan!");
                    return;
                }
                else
                {
                    errorProvider3.SetError(txtEmail, string.Empty);
                    cmd.Parameters.AddWithValue("email", txtEmail.Text);
                }

                //Unos LOZINKA
                if(string.IsNullOrEmpty(txtLozinka.Text.Trim()))
                {
                    errorProvider4.SetError(txtLozinka, "Unesite lozinku!");
                    return;
                }
                else if(txtLozinka.Text.Length < 5)
                {
                    errorProvider4.SetError(txtLozinka, "Lozinka mora da ima 5 karaktera");
                    return;
                }
                else
                {
                    errorProvider4.SetError(txtLozinka, string.Empty);
                    cmd.Parameters.AddWithValue("lozinka", txtLozinka.Text);
                }
                //Unov VRSTA
                cmd.Parameters.AddWithValue("vrsta", "kupac");


                //Resetovanje forme
                txtEmail.Text = "";
                txtIme.Text = "";
                txtLozinka.Text = "";
                txtPrezime.Text = "";

                int rezultat = cmd.ExecuteNonQuery();
                if (rezultat == 0)
                    MessageBox.Show("Došlo je do greške");
                else
                {
                    MessageBox.Show("Uspesna registracija!");
                }
            }
            catch (Exception ex)
            {
             // MessageBox.Show("Molimo Vas unesite sva polja validno!");
                MessageBox.Show(ex.Message);

            }
            finally
            {
                dbs.zatvoriKonekciju();
            }
        }

        private void Btn_nazad(object sender, EventArgs e)
        {
            this.Hide();
            Form_Login frm_log = new Form_Login();
            frm_log.ShowDialog();
            this.Close();
        }
    }
    }

