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
            System.Windows.Application.Current.Shutdown();
        }

        private void ObrisiNalogButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var BrisanjeNaloga = new BrisanjeNaloga();
            BrisanjeNaloga.Show();
        }

        private void RegistrujDonoraButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var RegistrovanjeDonora = new RegistrovanjeDonora();
            RegistrovanjeDonora.Show();

        }

        private void IzlogujSeButton_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();

        }

       

        private void PregledDonoraButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var PregledDonora = new PregledDonora();
            PregledDonora.Show();
        }


        

        private void btnRegPacijenta_Click(object sender, RoutedEventArgs e)
        {
            RegistrovanjePacijenta prozor = new RegistrovanjePacijenta();
            this.Visibility = Visibility.Hidden;
            prozor.Show();
        }

        private void PregledPacijenataButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var PregledPacijenata = new PregledPacijenata();
            PregledPacijenata.Show();
        }

        private void btnDonacija_Click(object sender, RoutedEventArgs e)
        {
            Donacija prozor = new Donacija();
            this.Visibility = Visibility.Hidden;
            prozor.Show();
        }

        private void btnPregledDonacija_Click(object sender, RoutedEventArgs e)
        {
            PregledDonacija prozor = new PregledDonacija();
            this.Visibility= Visibility.Hidden;
            prozor.Show();
        }
    }
}
