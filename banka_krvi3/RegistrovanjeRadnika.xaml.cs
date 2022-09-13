using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Interaction logic for RegistrovanjeRadnika.xaml
    /// </summary>
    public partial class RegistrovanjeRadnika : Window
    {
        public RegistrovanjeRadnika()
        {
            InitializeComponent();
        }
        string MyConString = "SERVER=127.0.0.1;" + "DATABASE=bankakrvi;" + "UID=root;" + "PASSWORD=root03102000;";

        private void RegistrovanjeRadnikaRegistrujButton_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrovanjeRadnikaImeTextBox.Text.Length == 0 || RegistrovanjeRadnikaPrezimeTextBox.Text.Length == 0 || RegistrovanjeRadnikaDatumRodjenjaTextBox.Text.Length == 0 || RegistrovanjeRadnikaEmailAdresaTextBox.Text.Length == 0 || RegistrovanjeRadnikaKorisnickoImeTextBox.Text.Length == 0 || RegistrovanjeRadnikaSifraTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja!");
            }
            else {
                MySqlConnection connection = new MySqlConnection(MyConString);
                connection.Open();

                string query = "insert into korisnik (Ime, Prezime, DatumRodjenja, Email, KorisnickoIme, Sifra) values ('"+ RegistrovanjeRadnikaImeTextBox.Text + "', '"+ RegistrovanjeRadnikaPrezimeTextBox.Text + "', '"+ RegistrovanjeRadnikaDatumRodjenjaTextBox.Text + "', '"+ RegistrovanjeRadnikaEmailAdresaTextBox.Text + "', '"+ RegistrovanjeRadnikaKorisnickoImeTextBox.Text + "', '"+ RegistrovanjeRadnikaSifraTextBox.Text + "')";
                MySqlCommand cmdSel = new MySqlCommand(query, connection);
                var queryResult1 = cmdSel.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Radnik uspesno registrovan!");

                RegistrovanjeRadnikaImeTextBox.Text = "";
                RegistrovanjeRadnikaPrezimeTextBox.Text = "";
                RegistrovanjeRadnikaDatumRodjenjaTextBox.Text = "";
                RegistrovanjeRadnikaEmailAdresaTextBox.Text = "";
                RegistrovanjeRadnikaKorisnickoImeTextBox.Text = "";
                RegistrovanjeRadnikaSifraTextBox.Text = "";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}
