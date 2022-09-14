using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
        string krvGDonor;
        string krvGPacijent;
        DateTime now = DateTime.Now;

        
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
            dr.Close();

            var queryResult = cmdSel.ExecuteReader();                                                                         //id DONOR
            queryResult.Read();
            kljucD=queryResult.GetString(0);
            
            queryResult.Close();

            string query2= "SELECT idPacijenta FROM pacijent WHERE pacijent.Ime = '" + cbPrezimeP.Text + "'";
            MySqlCommand cmdSel2 = new MySqlCommand(query2, connection);
            var queryResult2 = cmdSel2.ExecuteReader();
            queryResult2.Read();                                                                                             // id pacijent
            kljucP = queryResult2.GetString(0);
            
            queryResult2.Close();

            string query3 = "SELECT KrvnaGrupa FROM donor WHERE donor.Ime = '" + cbImeD.Text + "'";
            MySqlCommand cmdSel3 = new MySqlCommand(query3, connection);
            var queryResult3 = cmdSel3.ExecuteReader();
            queryResult3.Read();                                                                                             // krvna grupa donora
            krvGDonor = queryResult3.GetString(0);
            
            queryResult3.Close();

            string query4 = "SELECT KrvnaGrupa FROM pacijent WHERE pacijent.Ime = '" + cbPrezimeP.Text + "'";
            MySqlCommand cmdSel4 = new MySqlCommand(query4, connection);
            var queryResult4 = cmdSel4.ExecuteReader();
            queryResult4.Read();                                                                                             // krvna grupa pacijent
            krvGPacijent = queryResult4.GetString(0);
            
            queryResult4.Close();

            if (krvGDonor == "A+")
            {
                if (krvGPacijent == "A+" || krvGPacijent == "AB+")
                {

                    string query = "insert into donacija (Donor, Pacijent, DatumPreuzimanja) values ('" + kljucD + "', '" + kljucP + "', '" + now + "')";
                    cmdSel = new MySqlCommand(query, connection);
                    var queryResult1 = cmdSel.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Krvne grupe nisu kompatibilne!");
                }
            }
            else if (krvGDonor == "O+")
            {
                if (krvGPacijent == "O+" || krvGPacijent == "A+" || krvGPacijent == "B+" || krvGPacijent == "AB+")
                {
                    string query = "insert into donacija (Donor, Pacijent, DatumPreuzimanja) values ('" + kljucD + "', '" + kljucP + "', '" + now + "')";
                    cmdSel = new MySqlCommand(query, connection);
                    var queryResult1 = cmdSel.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Krvne grupe nisu kompatibilne!");
                }
            }
            else if (krvGDonor == "B+")
            {
                if (krvGPacijent == "B+" || krvGPacijent == "AB+")
                {
                    string query = "insert into donacija (Donor, Pacijent, DatumPreuzimanja) values ('" + kljucD + "', '" + kljucP + "', '" + now + "')";
                    cmdSel = new MySqlCommand(query, connection);
                    var queryResult1 = cmdSel.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Krvne grupe nisu kompatibilne!");
                }
            }
            else if (krvGDonor == "AB+")
            {
                if (krvGPacijent == "AB+")
                {
                    string query = "insert into donacija (Donor, Pacijent, DatumPreuzimanja) values ('" + kljucD + "', '" + kljucP + "', '" + now + "')";
                    cmdSel = new MySqlCommand(query, connection);
                    var queryResult1 = cmdSel.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Krvne grupe nisu kompatibilne!");
                }

            }
            else if (krvGDonor == "A-")
            {
                if (krvGPacijent == "A+" || krvGPacijent == "A-" || krvGPacijent == "AB+" || krvGPacijent == "AB-")
                {
                    string query = "insert into donacija (Donor, Pacijent, DatumPreuzimanja) values ('" + kljucD + "', '" + kljucP + "', '" + now + "')";
                    cmdSel = new MySqlCommand(query, connection);
                    var queryResult1 = cmdSel.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Krvne grupe nisu kompatibilne!");
                }

            }
            else if (krvGDonor == "O-")
            {          
                    string query = "insert into donacija (Donor, Pacijent, DatumPreuzimanja) values ('" + kljucD + "', '" + kljucP + "', '" + now + "')";
                cmdSel = new MySqlCommand(query, connection);
                var queryResult1 = cmdSel.ExecuteNonQuery();
            }
            else if (krvGDonor == "B-")
            {
                if (krvGPacijent == "B+" || krvGPacijent == "B-" || krvGPacijent == "AB+" || krvGPacijent == "AB-")
                {
                    string query = "insert into donacija (Donor, Pacijent, DatumPreuzimanja) values ('" + kljucD + "', '" + kljucP + "', '" + now + "')";
                    cmdSel = new MySqlCommand(query, connection);
                    var queryResult1 = cmdSel.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Krvne grupe nisu kompatibilne!");
                }

            }
            else if (krvGDonor == "AB-")
            {
                if (krvGPacijent == "AB+" || krvGPacijent == "AB-")
                {
                    string query = "insert into donacija (Donor, Pacijent, DatumPreuzimanja) values ('" + kljucD + "', '" + kljucP + "', '" + now + "')";
                    cmdSel = new MySqlCommand(query, connection);
                    var queryResult1 = cmdSel.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Krvne grupe nisu kompatibilne!");
                }

            }
            MessageBox.Show("Uspesno donirana krv!");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var GlavniOpcioniMeni = new GlavniOpcioniMeni();
            GlavniOpcioniMeni.Show();
        }
    }
  }
