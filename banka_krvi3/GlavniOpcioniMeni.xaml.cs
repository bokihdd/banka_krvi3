using System;
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

namespace banka_krvi3
{
    /// <summary>
    /// Interaction logic for GlavniOpcioniMeni.xaml
    /// </summary>
    public partial class GlavniOpcioniMeni : Window
    {
        public GlavniOpcioniMeni()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();
        }

        private void ObrisiNalogButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var BrisanjeNaloga = new BrisanjeNaloga();
            BrisanjeNaloga.Show();
        }
    }
}
