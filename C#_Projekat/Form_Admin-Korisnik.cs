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
    public partial class Form_Admin_Korisnik : Form
    {
        Baza dbs;
        public Form_Admin_Korisnik()
        {
            InitializeComponent();
            dbs = new Baza();
        }

        private void Form_Admin_Korisnik_Load(object sender, EventArgs e)
        {
            MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter user = new MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
            MsSQL_ProdavnicaDataSet.korisniciDataTable korisnici = user.GetKorisnici();

            comboBox1.DataSource = korisnici;
            comboBox1.DisplayMember = "email";
            comboBox1.SelectedIndex = -1;

            txt_ime.Clear();
            txt_prezime.Clear();
            txt_email.Clear();
            txt_lozinka.Clear();

            //Popunjavanje cb vrste korisnika
            MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter vrsta = new MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
            MsSQL_ProdavnicaDataSet.korisniciDataTable vrsta_korisnika = vrsta.GetKorisnici();

            cb_vrsta.DataSource = vrsta_korisnika.DefaultView.ToTable(true,"vrsta_korisnika");
            cb_vrsta.DisplayMember = "vrsta_korisnika";
            cb_vrsta.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dbs.otvoriKonekciju();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbs.Konekcija;

                cmd.CommandText=@"Select ime,prezime,email,lozinka,vrsta_korisnika from korisnici where email='"+comboBox1.Text+"'";
                SqlDataReader d_reader = cmd.ExecuteReader();
                while (d_reader.Read())
                {
                    txt_ime.Text= d_reader.GetValue(0).ToString();
                    txt_prezime.Text= d_reader.GetValue(1).ToString();
                    txt_email.Text = d_reader.GetValue(2).ToString();
                    txt_lozinka.Text = d_reader.GetValue(3).ToString();

                    cb_vrsta.SelectedIndex = cb_vrsta.FindStringExact(d_reader.GetValue(4).ToString());
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbs.otvoriKonekciju();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbs.Konekcija;
                cmd.CommandText = @"UPDATE korisnici set ime='" + txt_ime.Text + "' ,prezime='" + txt_prezime.Text + "' ,email='" + txt_email.Text + "' ,lozinka='" + txt_lozinka.Text + "', vrsta_korisnika='"+cb_vrsta.Text+"' where email='" + comboBox1.Text + "'";

                //Izmena IME
                if (string.IsNullOrEmpty(txt_ime.Text.Trim()))
                {
                    errorProvider1.SetError(txt_ime, "Unesite ime");
                }
                else
                {
                    errorProvider1.SetError(txt_ime, string.Empty);
                    cmd.Parameters.AddWithValue("ime", txt_ime.Text);
                }

                //Izmena PREZIME
                if (string.IsNullOrEmpty(txt_prezime.Text.Trim()))
                {
                    errorProvider2.SetError(txt_prezime, "Unesite prezime");
                }
                else
                {
                    errorProvider2.SetError(txt_prezime, string.Empty);
                    cmd.Parameters.AddWithValue("prezime", txt_prezime.Text);
                }

                //Izmena EMAIL
                //Proverava da li email vec postoji
                MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter email = new MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
                MsSQL_ProdavnicaDataSet.korisniciDataTable dt_mail = email.GetDataBy_Email(txt_email.Text);


                //Proverava da li postojeci Email odgovara trenutnom korisniku
                MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter email_id = new MsSQL_ProdavnicaDataSetTableAdapters.korisniciTableAdapter();
                MsSQL_ProdavnicaDataSet.korisniciDataTable dt_mail_id = email_id.Get_Email_by_ID(Convert.ToInt16(Form_Login.id));

                if (string.IsNullOrEmpty(txt_email.Text.Trim()))
                {
                    errorProvider3.SetError(txt_email, "Unesite Email");
                }
                else if (dt_mail.Rows.Count > 0 && dt_mail_id.Rows.Count < 1)
                {
                    errorProvider3.SetError(txt_email, "Email je već registrovan!");
                }
                else
                {
                    errorProvider3.SetError(txt_email, string.Empty);
                    cmd.Parameters.AddWithValue("email", txt_email.Text);
                }

                //Izmena LOZINKA
                if (string.IsNullOrEmpty(txt_lozinka.Text.Trim()))
                {
                    errorProvider4.SetError(txt_lozinka, "Unesite lozinku!");
                }
                else if (txt_lozinka.Text.Length < 5)
                {
                    errorProvider4.SetError(txt_lozinka, "Lozinka mora da ima 5 karaktera");
                }
                else
                {
                    errorProvider4.SetError(txt_lozinka, string.Empty);
                    cmd.Parameters.AddWithValue("lozinka", txt_lozinka.Text);
                }

                //Izmena vrsta_korisnika
                if(string.IsNullOrEmpty(cb_vrsta.Text.Trim()))
                {
                    errorProvider5.SetError(cb_vrsta, "Izaberite vrstu korisnika");
                }
                else
                {
                    errorProvider5.SetError(cb_vrsta, string.Empty);
                    cmd.Parameters.AddWithValue("vrsta_korisnika", cb_vrsta.Text);
                }

                int rezultat = cmd.ExecuteNonQuery();
                if (rezultat == 0)
                    MessageBox.Show("Doslo je do greske!");
                else
                {
                    MessageBox.Show("Uspesna izmena!");
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
        }

        private void btn_nazad_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ADMIN frm_admin = new Form_ADMIN();
            frm_admin.ShowDialog();
            this.Close();
        }
    }
}
