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
using System.Data.Sql;

namespace CS_Projekat
{
    public partial class Form_User_Settings : Form
    {
        Baza dbs;
        public Form_User_Settings()
        {
            InitializeComponent();
            dbs = new Baza();
        }

        private void Form_User_Settings_Load(object sender, EventArgs e)
        {
            try
            {
                dbs.otvoriKonekciju();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbs.Konekcija;

                cmd.CommandText = @"Select ime,prezime,email,lozinka,vrsta_korisnika from korisnici where id='" +Form_Login.id+"'";
                SqlDataReader d_reader = cmd.ExecuteReader();
                while(d_reader.Read())
                {
                    txtIme.Text = d_reader.GetValue(0).ToString();
                    txtPrezime.Text = d_reader.GetValue(1).ToString();
                    txtEmail.Text = d_reader.GetValue(2).ToString();
                    txtLozinka.Text = d_reader.GetValue(3).ToString();
                    txt_vrsta.Text = d_reader.GetValue(4).ToString();
                }
                dbs.zatvoriKonekciju();
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

        int brojac_klikova = 0;
        private void btn_izmeni(object sender, EventArgs e)
        {
            brojac_klikova++;

            switch(brojac_klikova)
            {
                case 0:
                    txtIme.ReadOnly = true;
                    txtPrezime.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtLozinka.ReadOnly = true;

                    button1.Text = "Izmeni";
                    break;

                case 1:
                    txtIme.ReadOnly = false;
                    txtPrezime.ReadOnly = false;
                    txtEmail.ReadOnly = false;
                    txtLozinka.ReadOnly = false;

                    button1.Text = "Sačuvaj izmene";
                    break;

                case 2:                  
                    try
                    {
                        dbs.otvoriKonekciju();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = dbs.Konekcija;
                        cmd.CommandText = @"UPDATE korisnici set ime='" + txtIme.Text + "' ,prezime='" + txtPrezime.Text + "' ,email='" + txtEmail.Text + "' ,lozinka='" + txtLozinka.Text + "' where id='"+Convert.ToInt32(Form_Login.id)+"'";

                        //Izmena IME
                        if (string.IsNullOrEmpty(txtIme.Text.Trim()))
                        {
                            errorProvider1.SetError(txtIme, "Unesite ime");
                            brojac_klikova--;
                            return;
                        }
                        else
                        {
                            errorProvider1.SetError(txtIme, string.Empty);
                            cmd.Parameters.AddWithValue("ime", txtIme.Text);
                        }

                        //Izmena PREZIME
                        if (string.IsNullOrEmpty(txtPrezime.Text.Trim()))
                        {
                            errorProvider2.SetError(txtPrezime, "Unesite prezime");
                            brojac_klikova--;
                            return;
                        }
                        else
                        {
                            errorProvider2.SetError(txtPrezime, string.Empty);
                            cmd.Parameters.AddWithValue("prezime", txtPrezime.Text);
                        }

                        //Izmena EMAIL
                        //Proverava da li email vec postoji
                        MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter email = new MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
                        MsSQL_ProdavnicaDataSet.korisniciDataTable dt_mail = email.GetDataBy_Email(txtEmail.Text);


                        //Proverava da li postojeci Email odgovara trenutnom korisniku
                        MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter email_id = new MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
                        MsSQL_ProdavnicaDataSet.korisniciDataTable dt_mail_id = email_id.Get_Email_by_ID(Convert.ToInt16(Form_Login.id));

                        if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                        {
                            errorProvider3.SetError(txtEmail, "Unesite Email");
                            brojac_klikova=1;
                            return;
                        }
                        else if (dt_mail.Rows.Count > 0 && dt_mail_id.Rows.Count < 1)
                        {
                            errorProvider3.SetError(txtEmail, "Email je već registrovan!");
                            brojac_klikova=1;
                            return;
                        }
                        else
                        {
                            errorProvider3.SetError(txtEmail, string.Empty);
                            cmd.Parameters.AddWithValue("email", txtEmail.Text);
                        }

                        //Izmena LOZINKA
                        if (string.IsNullOrEmpty(txtLozinka.Text.Trim()))
                        {
                            errorProvider4.SetError(txtLozinka, "Unesite lozinku!");
                            brojac_klikova=1;
                            return;
                        }
                        else if (txtLozinka.Text.Length < 5)
                        {
                            errorProvider4.SetError(txtLozinka, "Lozinka mora da ima 5 karaktera");
                            brojac_klikova = 1;
                            return;
                        }
                        else
                        {
                            errorProvider4.SetError(txtLozinka, string.Empty);
                            cmd.Parameters.AddWithValue("lozinka", txtLozinka.Text);
                        }

                        int rezultat = cmd.ExecuteNonQuery();
                        if (rezultat == 0)
                            MessageBox.Show("Doslo je do greske!");
                        else
                        {
                            MessageBox.Show("Uspesno sačuvano!");
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Molimo Vas unesite sva polja validno!");
                        MessageBox.Show(ex.Message);

                    }
                    finally
                    {
                        dbs.zatvoriKonekciju();
                    }
                    break;

                default:
                    brojac_klikova = 0;
                    break;
            }
        
        }
    }
}
