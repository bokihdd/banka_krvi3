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
using System.Configuration;

namespace banka_krvi3
{
    /// <summary>
    /// Interaction logic for PregledDonacija.xaml
    /// </summary>
    public partial class PregledDonacija : Window
    {
        public PregledDonacija()
        {
            InitializeComponent();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select donacija.idDonacije,donor.ime,pacijent.ime,donacija.datumpreuzimanja FROM donor,pacijent,donacija WHERE donacija.donor=donor.idDonor AND donacija.pacijent=pacijent.idPacijenta";
            sqlconn.Open();
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, sqlconn);
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dtDonacija.ItemsSource = dt.DefaultView;
            sqlconn.Close();


        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var GlavniOpcioniMeni = new GlavniOpcioniMeni();
            GlavniOpcioniMeni.Show();
        }
    }
}
