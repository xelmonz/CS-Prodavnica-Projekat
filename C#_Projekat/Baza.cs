using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CS_Projekat
{
    class Baza
    {
        SqlConnection konekcija;

        public Baza()
        {
            konekcija = new SqlConnection();
            konekcija.ConnectionString = "Data Source=DESKTOP-M0UKO72;Initial Catalog=Prodavnica;Integrated Security=True";
        }

      public SqlConnection Konekcija { get => konekcija; set => konekcija = value; }
        public void otvoriKonekciju()
        {
            if (Konekcija != null)
                Konekcija.Open();
        }
        public void zatvoriKonekciju()
        {
            if (Konekcija != null)
                Konekcija.Close();
        }
    }
}
