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
    /// Interaction logic for PregledPacijenata.xaml
    /// </summary>
    public partial class PregledPacijenata : Window
    {
        public PregledPacijenata()
        {
            InitializeComponent();
        }

        string MyConString = "SERVER=127.0.0.1;" + "DATABASE=bankakrvi;" + "UID=root;" + "PASSWORD=root03102000;";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string query = "select * from pacijent";
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand cmdSel = new MySqlCommand(query, connection);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
            da.Fill(dt);
            ListaPacijenataDataGrid.DataContext = dt;

        }

        private void PretraziButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImeTextBox.Text.Length == 0 || PrezimeTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja!");
            }
            else
            {
                string query = "select * from pacijent where Ime = '" + ImeTextBox.Text + "' and Prezime = '" + PrezimeTextBox.Text + "'";
                MySqlConnection connection = new MySqlConnection(MyConString);
                MySqlCommand cmdSel = new MySqlCommand(query, connection);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                da.Fill(dt);
                ListaPacijenataDataGrid.DataContext = dt;
            }

        }

        private void ObrisiButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImeTextBox.Text.Length == 0 || PrezimeTextBox.Text.Length == 0)
            {
                MessageBox.Show("Popunite sva polja!");
            }
            else
            {
                string query = " delete from pacijent where Ime = '" + ImeTextBox.Text + "' and Prezime = '" + PrezimeTextBox.Text + "'";
                MySqlConnection connection = new MySqlConnection(MyConString);
                connection.Open();

                MySqlCommand cmdSel = new MySqlCommand(query, connection);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                da.Fill(dt);

                ListaPacijenataDataGrid.DataContext = dt;


                ListaPacijenataDataGrid.DataContext = null;


                string sql = "select * from pacijent";
                connection = new MySqlConnection(MyConString);
                cmdSel = new MySqlCommand(sql, connection);
                dt = new DataTable();
                da = new MySqlDataAdapter(cmdSel);
                da.Fill(dt);
                ListaPacijenataDataGrid.DataContext = dt;


            }

        }

        private void OsveziButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from pacijent";
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand cmdSel = new MySqlCommand(query, connection);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
            da.Fill(dt);
            ListaPacijenataDataGrid.DataContext = dt;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var GlavniOpcioniMeni = new GlavniOpcioniMeni();
            GlavniOpcioniMeni.Show();
        }
    }
}
