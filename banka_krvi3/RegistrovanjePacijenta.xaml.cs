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
using MySql.Data.MySqlClient;

namespace banka_krvi3
{
    /// <summary>
    /// Interaction logic for RegistrovanjePacijenta.xaml
    /// </summary>
    public partial class RegistrovanjePacijenta : Window
    {

        public RegistrovanjePacijenta()
        {
            InitializeComponent();



        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            string MyConString = "SERVER=127.0.0.1;" + "DATABASE=bankakrvi;" + "UID=root;" + "PASSWORD=root03102000;";


            if (txtIme.Text == "" || txtPrezime.Text == "" || txtDatum.Text == "" || cbKrvnaGrupa.SelectedIndex == -1)
            {
                MessageBox.Show("Popunite sva polja", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(MyConString);
                connection.Open();

                string query = "insert into pacijent (Ime, Prezime, GodinaRodjenja, KrvnaGrupa) values ('" + txtIme.Text + "', '" + txtPrezime.Text + "', '" + txtDatum.Text + "', '" + cbKrvnaGrupa.Text + "' ) ";
                MySqlCommand cmdSel = new MySqlCommand(query, connection);
                var queryResult1 = cmdSel.ExecuteNonQuery();
                connection.Close();


                MessageBox.Show("Pacijent uspesno registrovan!");

                txtIme.Text = "";
                txtPrezime.Text = "";
                txtDatum.Text = "";
                cbKrvnaGrupa.SelectedIndex = -1;

            }
            }

        private void Window_Closed(object sender, EventArgs e)
        {
            var GlavniOpcioniMeni = new GlavniOpcioniMeni();
            GlavniOpcioniMeni.Show();
        }
    }

  
    }


