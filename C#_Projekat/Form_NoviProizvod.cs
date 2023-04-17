using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace CS_Projekat
{
    public partial class Form_NoviProizvod : Form
    {
        Baza dbs;
        MsSQL_ProdavnicaDataSet ds;
        public Form_NoviProizvod()
        {
            InitializeComponent();
            dbs = new Baza();
        }

        public Form_NoviProizvod(MsSQL_ProdavnicaDataSet ds) : this()
        {
            this.ds = ds;
        }

        private void Form_NoviProizvod_Load(object sender, EventArgs e)
        {
            MsSQL_ProdavnicaDataSetTableAdapters.kategorijaTableAdapter kate = new MsSQL_ProdavnicaDataSetTableAdapters.kategorijaTableAdapter();
            MsSQL_ProdavnicaDataSet.kategorijaDataTable dt_kate = kate.GetData();

            ////ToTable(distinct ili ne, ime kolone po kojoj se vracaju redovi)
            comboBox1.DataSource = dt_kate.DefaultView.ToTable(true, "kategorija");
            comboBox1.DisplayMember = "kategorija";
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbs.otvoriKonekciju();
                //OleDbCommand cmd = new OleDbCommand();
                //cmd.Connection = dbs.Conn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbs.Konekcija;
                //_______________________________

                cmd.CommandText = @"INSERT INTO Proizvod(naziv,kategorija,cena,kolicina)
                    values (@naziv,@kategorija,@cena,@kolicina)";

                MsSQL_ProdavnicaDataSetTableAdapters.proizvodTableAdapter ime_proizvoda = new MsSQL_ProdavnicaDataSetTableAdapters.proizvodTableAdapter();
                MsSQL_ProdavnicaDataSet.proizvodDataTable dt_naziv = ime_proizvoda.Get_Provera_postojeceg_proizvoda(txtNaziv.Text);

                // Naziv
                if (Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z ]+$") && dt_naziv.Rows.Count==0)
                {
                    cmd.Parameters.AddWithValue("naziv", txtNaziv.Text);
                }
                else if (dt_naziv.Rows.Count > 0)
                {
                    MessageBox.Show("Proizvod već postoji");
                    return;
                }
                else
                {
                    MessageBox.Show("Unesite validan naziv!");
                }

                // Kategorija
                cmd.Parameters.AddWithValue("kategorija", comboBox1.Text);

                // Cena
                if (Convert.ToDouble(txtCena.Text) > 0)
                {
                    cmd.Parameters.AddWithValue("cena", Convert.ToDouble(txtCena.Text));
                }
                else
                {
                    MessageBox.Show("Unesite validnu cenu!");
                }

                // Kolicina
                if (int.Parse(txtKolicina.Text) > 0)
                {
                    cmd.Parameters.AddWithValue("kolicina", int.Parse(txtKolicina.Text));
                }
                else
                {
                    MessageBox.Show("Unesite validnu količinu!");
                }

                int rezultat = cmd.ExecuteNonQuery();
                if (rezultat == 0)
                    MessageBox.Show("Doslo je do greske");
                    else
                    {
                        MessageBox.Show("Uspesno dodato!");
                    }
                txtCena.Text = "";
                txtKolicina.Text = "";
                txtNaziv.Text = "";
                comboBox1.SelectedItem = null;
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
