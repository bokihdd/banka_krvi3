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
            string connectionString = @"Data Source=DESKTOP-RB5QU9U\SQLEXPRESS; Initial Catalog=bankakrvi; Integrated Security=True;";


            if (txtIme.Text == "" || txtPrezime.Text == "" || txtDatum.Text == "" || cbKrvnaGrupa.SelectedIndex == -1)
            {
                MessageBox.Show("Popunite sva polja", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa;


                    sqlDa = new SqlDataAdapter("INSERT INTO pacijent (Ime,Prezime,KrvnaGrupa,GodinaRodjenja) VALUES ('" + txtIme.Text + "', '" + txtPrezime.Text + "','" + cbKrvnaGrupa.Text + "','" + txtDatum.Text + "')", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    MessageBox.Show("Uspesna registrovanje", "Uspesno", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtIme.Text = "";
                    txtPrezime.Text = "";
                    cbKrvnaGrupa.SelectedIndex = -1;
                    txtDatum.Text = "";

                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var GlavniOpcioniMeni = new GlavniOpcioniMeni();
            GlavniOpcioniMeni.Show();
        }
    }
}
