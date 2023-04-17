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
    public partial class Form_Izmena_Proizvoda : Form
    {
        Baza dbs;
        MsSQL_ProdavnicaDataSet ds;
        public Form_Izmena_Proizvoda()
        {
            InitializeComponent();
            dbs = new Baza();
        }

        public Form_Izmena_Proizvoda(MsSQL_ProdavnicaDataSet ds) : this()
        {
            this.ds = ds;
        }

        private void Form_Izmena_Proizvoda_Load(object sender, EventArgs e)
        {
            MsSQL_ProdavnicaDataSetTableAdapters.kategorijaTableAdapter kate = new MsSQL_ProdavnicaDataSetTableAdapters.kategorijaTableAdapter();
            MsSQL_ProdavnicaDataSet.kategorijaDataTable dt_kate = kate.GetData();

            MsSQL_ProdavnicaDataSetTableAdapters.proizvodTableAdapter proizvod = new MsSQL_ProdavnicaDataSetTableAdapters.proizvodTableAdapter();
            MsSQL_ProdavnicaDataSet.proizvodDataTable dt = proizvod.GetData();

            cb_naziv_proizvoda.DataSource = dt;
            cb_naziv_proizvoda.DisplayMember = "naziv";
            cb_naziv_proizvoda.SelectedIndex = -1;

            //ToTable(distinct ili ne, ime kolone po kojoj se vracaju redovi)
            cb_kategorija.DataSource = dt_kate.DefaultView.ToTable(true, "kategorija");
            cb_kategorija.DisplayMember = "kategorija";
            cb_kategorija.SelectedIndex = -1;

            txt_naziv.Clear();
            txt_cena.Clear();
            txt_kolicina.Clear();
        }

        private void btn_nazad_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ADMIN frm_admin = new Form_ADMIN();
            frm_admin.ShowDialog();
            this.Close();
        }

        private void cb_naziv_proizvoda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dbs.otvoriKonekciju();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbs.Konekcija;

                cmd.CommandText=@"Select naziv,kategorija,cena,kolicina from proizvod where naziv='"+cb_naziv_proizvoda.Text+"'";
                SqlDataReader d_reader = cmd.ExecuteReader();
                while (d_reader.Read())
                {
                    txt_naziv.Text =d_reader.GetValue(0).ToString();
                    txt_kolicina.Text = d_reader.GetValue(3).ToString();
                    txt_cena.Text = d_reader.GetValue(2).ToString();

                    //Nalazi kategoriju za izabrani proizvod
                    cb_kategorija.SelectedIndex= cb_kategorija.FindStringExact(d_reader.GetValue(1).ToString());
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


        private void btn_izmena_Click(object sender, EventArgs e)
        {
            try
            {
                dbs.otvoriKonekciju();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbs.Konekcija;
                cmd.CommandText = @"UPDATE proizvod set naziv='"+txt_naziv.Text+"', kategorija=N'"+cb_kategorija.Text+"', cena='"+Convert.ToDouble(txt_cena.Text)+"',kolicina='"+Convert.ToInt32(txt_kolicina.Text)+"' where naziv='"+cb_naziv_proizvoda.Text+"'";

                //Izmena naziv
                if (string.IsNullOrEmpty(txt_naziv.Text.Trim()))
                {
                    error_naziv.SetError(txt_naziv, "Unesite naziv");
                }
                else
                {
                    error_naziv.SetError(txt_naziv, string.Empty);
                    cmd.Parameters.AddWithValue("naziv", txt_naziv.Text);
                }

                //Izmena kategorija
                if (string.IsNullOrEmpty(cb_kategorija.Text.Trim()))
                {
                    error_kategorija.SetError(cb_kategorija, "Izaberite kategoriju");
                }
                else
                {
                    error_kategorija.SetError(cb_kategorija, string.Empty);
                    cmd.Parameters.AddWithValue("kategorija", cb_kategorija.Text);
                }

                //Izmena cena
                if(Convert.ToDouble(txt_cena.Text) > 0)
                {
                    cmd.Parameters.AddWithValue("cena",Convert.ToDouble(txt_cena.Text));
                }
                else
                {
                    error_cena.SetError(txt_cena, "Unesite validnu cenu");
                }

                //Izmena kolicina
                if(int.Parse(txt_kolicina.Text)>0 && int.Parse(txt_kolicina.Text) < 201)
                {
                    cmd.Parameters.AddWithValue("kolicina", int.Parse(txt_kolicina.Text));
                }
                else
                {
                    error_kolicina.SetError(txt_kolicina, "Unesite validnu kolicinu");
                }

                int rezultat = cmd.ExecuteNonQuery();
                if (rezultat == 0)
                    MessageBox.Show("Doslo je do greske!");
                else
                {
                    MessageBox.Show("Sačuvano!");
                }
            }
            catch
            {
                MessageBox.Show("Molimo Vas unesite sva polja validno!");
                //MessageBox.Show(ex.Message);

            }
            finally
            {
                dbs.zatvoriKonekciju();
            }
            
        }
    }
}
