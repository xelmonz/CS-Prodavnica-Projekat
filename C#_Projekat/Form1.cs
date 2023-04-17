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
    public partial class Form1 : Form
    {
        Baza dbs;
        MsSQL_ProdavnicaDataSet ds;
        MsSQL_ProdavnicaDataSetTableAdapters.proizvodTableAdapter pAda;

        public Form1()
        {
            InitializeComponent();
            ds = new MsSQL_ProdavnicaDataSet();
            pAda = new MsSQL_ProdavnicaDataSetTableAdapters.proizvodTableAdapter();
            txtRacun.Text = "0";
            dbs = new Baza();
        }

        //Za ID RACUNA
        static public int novi_idRacuna()
        {
            int provera = 0;
            do
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                int id = rand.Next(1, 999);

                MsSQL_ProdavnicaDataSetTableAdapters.racunTableAdapter id_racuna = new MsSQL_ProdavnicaDataSetTableAdapters.racunTableAdapter();
                MsSQL_ProdavnicaDataSet.racunDataTable dt_ID_provera = id_racuna.Get_Id_Racuna(id);

                if (dt_ID_provera.Rows.Count > 0)
                {
                    provera = 0;
                }
                else
                {
                    provera = 1;
                }
                return id;
            }
            while (provera<1);
        }

        public Form1(MsSQL_ProdavnicaDataSet ds) : this()
        {
            this.ds = ds;
        }
       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int kolicina = Convert.ToInt32(numericUpDown1.Value); //Broj proizvoda koji se dodaju
            int index = e.RowIndex;

            if (index >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                int stara_kolicina = Convert.ToInt32(selectedRow.Cells[4].Value.ToString());
                if (kolicina > 0 && kolicina <= stara_kolicina)
                {
                    // listBox1.Items.Add(selectedRow.Cells[1].Value.ToString().Trim().PadRight(20- selectedRow.Cells[1].Value.ToString().Length) + ',' + kolicina.ToString().Trim().PadRight(5 - kolicina.ToString().Trim().Length) + ',' + selectedRow.Cells[3].Value.ToString());
                    listBox1.Items.Add(selectedRow.Cells[1].Value.ToString() + ',' + kolicina + ',' + selectedRow.Cells[3].Value.ToString());
                    // Trenutna promena u datagrid
                    selectedRow.Cells[4].Value = stara_kolicina - kolicina;
                }
                else
                {
                    MessageBox.Show("Kolicina nije validna");
                    return;
                }

                //Prikaz ukupne cene
                int racun = 0;
                racun += Convert.ToInt32(selectedRow.Cells[3].Value) * kolicina;
                racun += Convert.ToInt32(txtRacun.Text);
                txtRacun.Text = racun.ToString();
            }
        }
        
        private void listUkloni_Click(object sender, EventArgs e)
        {
            int racun = 0;
            int cena = 0;
            int broj = 0;

            if (listBox1.SelectedItem == null)
            {
                return;
            }

            string naziv = listBox1.SelectedItem.ToString().Split(',')[0];
            int kolicina = Convert.ToInt32(listBox1.SelectedItem.ToString().Split(',')[1]);

            foreach (var p in ds.proizvod)
            {
                if (p.naziv.Equals(naziv))
                {
                    broj = p.kolicina;
                    broj = broj + kolicina;
                    cena = Convert.ToInt32(p.cena);
                    break;
                }
            }

            foreach (DataGridViewRow red in dataGridView1.Rows)
            {
                int index = red.Index;
                DataGridViewRow selected = dataGridView1.Rows[index];
                int kol = Convert.ToInt32(selected.Cells[4].Value.ToString());
                if (selected.Cells[1].Value.Equals(naziv))
                {
                    selected.Cells[4].Value = broj;
                }
            }
            //pAda.Fill(ds.proizvod);
            //dataGridView1.DataSource = ds.proizvod;
            //pAda.Update(ds.proizvod);

            racun = Convert.ToInt32(txtRacun.Text) - cena * kolicina;
            txtRacun.Text = racun.ToString();
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void listReset_Click(object sender, EventArgs e)
        {
            int kolicina;
            string naziv;

            foreach (object o in listBox1.Items)
            {
                string[] element = o.ToString().Split(',');
                naziv = element[0];
                kolicina = int.Parse(element[1]);
                int broj = 0;

                foreach (var p in ds.proizvod)
                {
                    if (p.naziv.Equals(naziv))
                    {
                        broj = p.kolicina; //stara kolicina
                        broj = broj + kolicina; //nova kolicina
                        break;
                    }
                }

                foreach (DataGridViewRow red in dataGridView1.Rows)
                {
                    int index = red.Index;
                    DataGridViewRow selected = dataGridView1.Rows[index];
                    int kol = Convert.ToInt32(selected.Cells[4].Value.ToString());
                    if (selected.Cells[1].Value.Equals(naziv))
                    {
                        selected.Cells[4].Value = broj;
                    }
                }
            }

            listBox1.Items.Clear();
            txtRacun.Text = "0".ToString();
        }

        private void Pretraga_Naziv(object sender, EventArgs e)
        {
            DataView dv = new DataView(ds.proizvod);
            dv.RowFilter = string.Format("Naziv LIKE '"+ txtPretraga.Text +"%'");
             // dv.RowFilter = string.Format("Naziv ='" + txtPretraga.Text + "'");

            pAda.Fill(ds.proizvod);
            dataGridView1.DataSource = dv;
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            //Provera
            int redovi = dataGridView1.Rows.Count;
            if (redovi < 1)
            {
                MessageBox.Show("Molimo Vas unesite pravilan naziv!");
            }
            txtPretraga.Text = "";
        }

        private void Pretraga_Kategorija(object sender, EventArgs e)
        {
            DataView dv = new DataView(ds.proizvod);
            dv.RowFilter = string.Format("Kategorija LIKE '" +txtPretraga.Text + "%'");
            //  dv.RowFilter = string.Format("Kategorija ='" + txtPretraga.Text + "'");

            pAda.Fill(ds.proizvod);
            dataGridView1.DataSource = dv;
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

            //Provera
            int redovi = dataGridView1.Rows.Count;
            if (redovi < 1)
            {
                MessageBox.Show("Molimo Vas unesite validnu kategoriju!");
            }
            txtPretraga.Text = "";
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            Form_NoviProizvod frm = new Form_NoviProizvod(ds);
            frm.Show();
        }

        private void btn_Naruci_Click(object sender, EventArgs e)
        {
            //Kreiranje ID_racuna
            int id_racun = novi_idRacuna();

            //Promena kolicine(Update)
            try
            {
                string naziv;
                int kolicina;
                dbs.otvoriKonekciju();

                foreach (object o in listBox1.Items)
                {
                    string[] element = o.ToString().Split(',');
                    naziv = element[0];
                    kolicina = int.Parse(element[1]);
                    int broj=0;

                    foreach (var p in ds.proizvod)
                    {
                        if (p.naziv.Equals(naziv))
                        {
                            broj = p.kolicina; //stara kolicina
                            //broj = p.kolicina - kolicina; //nova kolicina
                            break;
                        }
                    }
                    if (broj < 0)
                    {
                        MessageBox.Show("Nemamo dovoljno proizvoda " + naziv);
                        continue;
                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = dbs.Konekcija;
                    //__________________________________

                    cmd.CommandText = @"Update Proizvod set kolicina='" + broj + "' where naziv='" + naziv + "'";
                    int rezultat = cmd.ExecuteNonQuery();
                    if (rezultat == 0)
                        MessageBox.Show("Došlo je do greške");
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



            //Ubacivanje u tabelu RACUN
            try
            {
                dbs.otvoriKonekciju();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = dbs.Konekcija;
                //__________________________________

                cmd.CommandText = @"INSERT INTO Racun(id,id_korisnika,uk_cena,vreme,datum)
                 values (@id,@id_korisnika,@uk_cena,@vreme,@datum)";

                cmd.Parameters.AddWithValue("id", id_racun);
                cmd.Parameters.AddWithValue("id_korisnika", Form_Login.id);
                cmd.Parameters.AddWithValue("uk_cena", Convert.ToDouble(txtRacun.Text));
                cmd.Parameters.AddWithValue("vreme", DateTime.Now.ToLongTimeString());
                cmd.Parameters.AddWithValue("datum", DateTime.Now.ToShortDateString());

                int rezultat = cmd.ExecuteNonQuery();
                if (rezultat == 0)
                    MessageBox.Show("Došlo je do greške");
                else
                {
                    MessageBox.Show("Uspešno naručeno!");
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

            //Ubacivanje u tabelu STAVKA_RACUNA
            try
            {
                dbs.otvoriKonekciju();

                foreach (object o in listBox1.Items)
                {
                    int kolicina;
                    string naziv;
                    float cena;

                    string[] element = o.ToString().Split(',');
                    naziv = element[0];
                    kolicina = int.Parse(element[1]);
                    cena = int.Parse(element[2]);

                    SqlCommand cmd_insert = new SqlCommand();
                    cmd_insert.Connection = dbs.Konekcija;

                    cmd_insert.CommandText = @"Insert into stavka_racuna(id_racun,naziv,kolicina,cena)
                                            values(@id_racun,@naziv,@kolicina,@cena)";

                    cmd_insert.Parameters.AddWithValue("id_racun", id_racun);
                    cmd_insert.Parameters.AddWithValue("naziv", naziv);
                    cmd_insert.Parameters.AddWithValue("kolicina", kolicina);
                    cmd_insert.Parameters.AddWithValue("cena", cena * kolicina);

                    int rezultat = cmd_insert.ExecuteNonQuery();
                    if (rezultat == 0)
                        MessageBox.Show("Došlo je do greške");
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

            //Ubacivanje u tabelu STATISTIKA
            try
            {
                string naziv;
                int kolicina;
                dbs.otvoriKonekciju();

                foreach (object o in listBox1.Items)
                {
                    string[] element = o.ToString().Split(',');
                    naziv = element[0];
                    kolicina = int.Parse(element[1]);

                    DateTime dat = DateTime.Now;
                    string mesec = "0" + dat.Month;

                    SqlCommand cmd_insert = new SqlCommand();
                    cmd_insert.Connection = dbs.Konekcija;
                    SqlCommand cmd_update = new SqlCommand();
                    cmd_update.Connection= dbs.Konekcija;
                    //__________________________________
                    //provera da li postoji vec u STATISTIKA
                    MsSQL_ProdavnicaDataSetTableAdapters.statistikaTableAdapter stats = new MsSQL_ProdavnicaDataSetTableAdapters.statistikaTableAdapter();
                    MsSQL_ProdavnicaDataSet.statistikaDataTable dt = stats.GetDataBy_Provera_Meseca(naziv, dat.Month);

                    if(dt.Rows.Count>0)  //Ako ima
                    {
                        cmd_update.CommandText = @"UPDATE statistika set kolicina+='" + kolicina + "' where naziv='" + naziv + "' and month(datum)= '" + mesec + "'";
                        int rez = cmd_update.ExecuteNonQuery();
                        if (rez == 0)
                            MessageBox.Show("Došlo je do greške");
                    }

                    else //Ako nema
                    {
                        cmd_insert.CommandText = @"INSERT INTO Statistika(naziv,kolicina,datum)
                        values (@naziv,@kolicina,@datum)";

                        cmd_insert.Parameters.AddWithValue("naziv", naziv);
                        cmd_insert.Parameters.AddWithValue("kolicina", kolicina);
                        cmd_insert.Parameters.AddWithValue("datum", DateTime.Now.ToShortDateString());
                        int rezultat = cmd_insert.ExecuteNonQuery();
                        if (rezultat == 0)
                            MessageBox.Show("Došlo je do greške");
                    }

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
            listBox1.Items.Clear();
            txtRacun.Text = "0".ToString();
            numericUpDown1.ResetText();
            comboBox1.ResetText();
            dataGridView1.DataSource = null; //clear
        }
    
        private void btnRacuni_Click(object sender, EventArgs e)
        {
            Form_Racuni frm = new Form_Racuni(ds);
            frm.Show();
        }

        private void txtRacun_TextChanged(object sender, EventArgs e)
        {
            double provera = Convert.ToDouble(txtRacun.Text);
            if (provera == 0)
            {
                btn_Naruci.Enabled = false;
            }
            else
            {
                btn_Naruci.Enabled = true;
            }
        }

        private void btn_Statistika_Click(object sender, EventArgs e)
        {
            Form_Statistika frm = new Form_Statistika();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Prodavnica";

            MsSQL_ProdavnicaDataSetTableAdapters.kategorijaTableAdapter kate = new MsSQL_ProdavnicaDataSetTableAdapters.kategorijaTableAdapter();
            MsSQL_ProdavnicaDataSet.kategorijaDataTable dt_kate = kate.GetData();

            comboBox1.DataSource = dt_kate.DefaultView.ToTable(true, "kategorija");
            comboBox1.DisplayMember = "kategorija";
            comboBox1.SelectedIndex = -1;

            // lbl_user.Text = Form_Login.user_email;
            lbl_user.Text = "ID korisnika: "+Form_Login.id;

            dataGridView1.DataSource = null;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(ds.proizvod);
            //dv.RowFilter = string.Format("kategorija LIKE '%{0}%'", comboBox1.SelectedItem.ToString());
            dv.RowFilter = string.Format("kategorija LIKE '%{0}%'", comboBox1.Text);

            pAda.Fill(ds.proizvod);
            dataGridView1.DataSource = dv;
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Login frm_log = new Form_Login();
            frm_log.ShowDialog();
            this.Close();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            Form_User_Settings frm = new Form_User_Settings();
            frm.Show();
        }
    }
}
