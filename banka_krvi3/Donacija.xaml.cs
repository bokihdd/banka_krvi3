using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace banka_krvi3
{
    /// <summary>
    /// Interaction logic for Donacija.xaml
    /// </summary>
    public partial class Donacija : Window
    {
        string kljucD;
        string kljucP;
        public Donacija()
        {
            InitializeComponent();
            fillComboI();
            fillComboP();


        }


        void fillComboI()
        {
            string MyConString = "SERVER=127.0.0.1;" + "DATABASE=bankakrvi;" + "UID=root;" + "PASSWORD=root03102000;";
            string query = "SELECT * FROM donor";
            MySqlConnection connection = new MySqlConnection(MyConString);
            connection.Open();
            MySqlCommand cmdSel = new MySqlCommand(query, connection);
            MySqlDataReader dr = cmdSel.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(1);
                cbImeD.Items.Add(name);
            }
            connection.Close();
            dr.Close();
        }
        void fillComboP()
        {
            string MyConString = "SERVER=127.0.0.1;" + "DATABASE=bankakrvi;" + "UID=root;" + "PASSWORD=root03102000;";
            string query = "SELECT * FROM pacijent";
            MySqlConnection connection = new MySqlConnection(MyConString);
            connection.Open();
            MySqlCommand cmdSel = new MySqlCommand(query, connection);
            MySqlDataReader dr = cmdSel.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(1);
                cbPrezimeP.Items.Add(name);
            }
            connection.Close();
            dr.Close();

        }

        private void btnIzvrsiDonaciju_Click(object sender, RoutedEventArgs e)
        {
            string MyConString = "SERVER=127.0.0.1;" + "DATABASE=bankakrvi;" + "UID=root;" + "PASSWORD=root03102000;";
            string query1 = "SELECT idDonor FROM donor WHERE donor.Ime ='" + cbImeD.Text + "'";
            MySqlConnection connection = new MySqlConnection(MyConString);
            connection.Open();
            MySqlCommand cmdSel = new MySqlCommand(query1, connection);
            MySqlDataReader dr = cmdSel.ExecuteReader();
           var queryResult = cmdSel.ExecuteReader();                                                                         //DONOR
            queryResult.Read();
            kljucD=queryResult.GetString(0);
            MessageBox.Show(kljucD);
            queryResult.Close();

            string query2= "SELECT idPacijenta FROM pacijent WHERE pacijent.Ime = '" + cbPrezimeP.Text + "'";
            MySqlCommand cmdSel2 = new MySqlCommand(query2, connection);
            var queryResult2 = cmdSel2.ExecuteReader();
            queryResult2.Read();                                                                                             //pacijent
            kljucP = queryResult2.GetString(0);
            MessageBox.Show(kljucP);
            queryResult2.Close();



            

            

















        }
    }
  }
