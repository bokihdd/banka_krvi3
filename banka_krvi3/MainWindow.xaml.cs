using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using MySql.Data.MySqlClient;

namespace banka_krvi3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string MyConString = "SERVER=127.0.0.1;" + "DATABASE=bankakrvi;" + "UID=root;" + "PASSWORD=root03102000;";

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            RegistrovanjeRadnika prozor = new RegistrovanjeRadnika();
            this.Visibility = Visibility.Hidden;
            prozor.Show();
                    
        }

        private void btnLista_Click(object sender, RoutedEventArgs e)
        {
            ListaRadnika prozor = new ListaRadnika();
            this.Visibility= Visibility.Hidden;
            prozor.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnUlogujSe_Click(object sender, RoutedEventArgs e)
        {
            if (txtIme.Text.Length == 0 || txtSifra.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja!");
            }
            else {

                string username = txtIme.Text;
                string password = txtSifra.Text;

                try
                {
                    MySqlConnection connection = new MySqlConnection(MyConString);
                    connection.Open();                  
                    string query = "select * from korisnik where KorisnickoIme = '" + txtIme.Text + "' and Sifra = '" + txtSifra.Text + "'";
                    MySqlDataAdapter sda = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        username = txtIme.Text;
                        password = txtSifra.Text;

                        GlavniOpcioniMeni prozor = new GlavniOpcioniMeni();
                        this.Visibility = Visibility.Hidden;
                        prozor.Show();
                    }
                    else {
                        MessageBox.Show("Pogresno korisnicko ime ili sifra!");
                    }
                    

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Error!");
                }
                
                    
                    

            }
        }
    }
}
