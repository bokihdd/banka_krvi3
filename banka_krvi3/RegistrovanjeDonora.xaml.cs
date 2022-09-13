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
using System.Windows.Shapes;

using MySql.Data.MySqlClient;

namespace banka_krvi3
{
    /// <summary>
    /// Interaction logic for RegistrovanjeDonora.xaml
    /// </summary>
    public partial class RegistrovanjeDonora : Window
    {
        public RegistrovanjeDonora()
        {
            InitializeComponent();
        }
        string MyConString = "SERVER=127.0.0.1;" + "DATABASE=bankakrvi;" + "UID=root;" + "PASSWORD=root03102000;";


        private void RegistrovanjeDonoraButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImeTextBox.Text.Length == 0 || PrezimeTextBox.Text.Length == 0 || GodinaRodjenjaTextBox.Text.Length == 0 || DatumDonacijeTextBox.Text.Length == 0 || KrvnaGrupaComboBox.SelectedIndex == -1 || KolicinaKrviTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja!");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(MyConString);
                connection.Open();

                string query = "insert into donor (Ime, Prezime, GodinaRodjenja, DatumDoniranja, KrvnaGrupa, KolicinaKrvi) values ('"+ ImeTextBox .Text+ "', '"+ PrezimeTextBox.Text +"', '"+ GodinaRodjenjaTextBox.Text + "', '"+ DatumDonacijeTextBox.Text + "', '"+ KrvnaGrupaComboBox.Text + "', '"+ KolicinaKrviTextBox.Text + "') ";
                MySqlCommand cmdSel = new MySqlCommand(query, connection);
                var queryResult1 = cmdSel.ExecuteNonQuery();
                connection.Close();
               

                MessageBox.Show("Donor uspesno registrovan!");

                ImeTextBox.Text = "";
                PrezimeTextBox.Text = "";
                GodinaRodjenjaTextBox.Text = "";
                DatumDonacijeTextBox.Text = "";
                KrvnaGrupaComboBox.SelectedIndex = -1;
                KolicinaKrviTextBox.Text = "";
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var GlavniOpcioniMeni = new GlavniOpcioniMeni();
            GlavniOpcioniMeni.Show();
        }
    }
}
