using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Projekat
{
    public partial class Form_Statistika : Form
    {
        MsSQL_ProdavnicaDataSet ds;
        MsSQL_ProdavnicaDataSetTableAdapters.proizvodTableAdapter pAda;
        MsSQL_ProdavnicaDataSetTableAdapters.statistikaTableAdapter sAda;
        public Form_Statistika()
        {
            InitializeComponent();
            ds = new MsSQL_ProdavnicaDataSet();
            pAda = new MsSQL_ProdavnicaDataSetTableAdapters.proizvodTableAdapter();
            sAda = new MsSQL_ProdavnicaDataSetTableAdapters.statistikaTableAdapter();
        }

        public Form_Statistika(MsSQL_ProdavnicaDataSet ds):this()
        {
            this.ds = ds;
        }

        private void Form_Statistika_Load(object sender, EventArgs e)
        {
            pAda.Fill(ds.proizvod);
            comboBox2.DataSource = null;
            comboBox2.BindingContext = new BindingContext();
            comboBox2.DisplayMember = "naziv";
            comboBox2.ValueMember = "naziv";
            comboBox2.DataSource = ds.proizvod.CopyToDataTable();
        }

        public void getMesec(int mesec)
        {
            listBox1.Items.Clear();
            sAda.Fill(ds.statistika);
            var q = from x in ds.statistika
                    where mesec == x.datum.Month
                    select x;
            int broj = 0;
            if(q.Count()>0)
            {
                foreach(var p in q)
                {
                    broj += p.kolicina;
                }

                foreach(var x in q)
                {
                    //Dodavanje u listbox
                    double procenat = (double)x.kolicina * 100 / broj;
                    listBox1.Items.Add(x.naziv.Trim().PadRight(30 - x.naziv.Trim().Length) + "," + x.kolicina.ToString().Trim().PadRight(10 - x.kolicina.ToString().Trim().Length) + "," + procenat.ToString("#.#") + "%");
                }
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem.ToString())
            {
                case "Januar": getMesec(1);
                    break;
                case "Februar": getMesec(2);
                    break;
                case "Mart": getMesec(3);
                    break;
                case "April": getMesec(4);
                    break;
                case "Maj": getMesec(5);
                    break;
                case "Jun": getMesec(6);
                    break;
                case "Jul": getMesec(7);
                    break;
                case "Avgust": getMesec(8);
                    break;
                case "Septembar": getMesec(9);
                    break;
                case "Oktobar": getMesec(10);
                    break;
                case "Novembar": getMesec(11);
                    break;
                case "Decembar": getMesec(12);
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sAda.Fill(ds.statistika);
            this.Paint += Draw;
            this.Invalidate();
        }

        public string mesec(int rbr)
        {
            string str = "";
            switch (rbr)
            {
                case 1: 
                    str = "Januar"; break;
                case 2: 
                    str = "Februar"; break;
                case 3: 
                    str = "Mart"; break;
                case 4: 
                    str = "April"; break;
                case 5: 
                    str = "Maj"; break;
                case 6: 
                    str = "Jun"; break;
                case 7: 
                    str = "Jul"; break;
                case 8: 
                    str = "Avgust"; break;
                case 9: 
                    str = "Septembar"; break;
                case 10: 
                    str = "Oktobar"; break;
                case 11: 
                    str = "Novembar"; break;
                case 12: 
                    str = "Decembar"; break;
            }
            return str;
        }
        private void Draw(object sender,PaintEventArgs e)
        {
            string izabran = comboBox2.SelectedValue.ToString();
           
            var q = from z in ds.statistika
                    where z.naziv == izabran
                    select z;

            if(q.Count()>0)
            {
                int i = 0;
                float ugao = 0;
                float suma = 0;
                int vis_tekst = 50;

                Brush[] olovke =
               {
                    Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.Yellow, Brushes.Black, Brushes.Purple, Brushes.DarkMagenta,
                    Brushes.Cyan, Brushes.LightGreen, Brushes.LightPink, Brushes.LightSkyBlue, Brushes.DarkGoldenrod
                };

                foreach (var k in q)
                {
                    suma += (float)k.kolicina;
                }

                foreach(var g in q)
                {
                    //Crtanje kruga
                    e.Graphics.FillPie(olovke[i], new Rectangle(318, 100, 150, 150), ugao, (g.kolicina * 360) / suma);

                    //boje
                    Rectangle rtn = new Rectangle();
                    rtn = new Rectangle(610, vis_tekst, 20, 20);
                    e.Graphics.FillRectangle(olovke[i], rtn);
                    i++;
                    //Crtanje teksta
                    Font f = new Font("Times New Roman", 10);
                    string month = mesec(g.datum.Month);
                    e.Graphics.DrawString(month + "," + g.kolicina.ToString() + "," + (g.kolicina * 100 / suma).ToString("#.#")+"%" ,f,Brushes.Black,500,vis_tekst);

                    ugao += (g.kolicina * 360) / suma;
                    vis_tekst += 40;
                }
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
