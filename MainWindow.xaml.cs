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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Biblioteka_system.Client;
using Biblioteka_system.Main;
using Color = Biblioteka_system.Main.Color;
using System.Windows.Threading;

namespace Biblioteka_system
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         BibliotekaEntities db = new BibliotekaEntities();
        DispatcherTimer timer = new DispatcherTimer();
       
            
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                //timer.Interval = new TimeSpan(0, 0, 0, 1);
                timer.Tick += delegate
                  {
                      DateTime time = DateTime.Now;
                      this.lblClock.Content = time.ToString("HH:mm:ss");
                  };
                timer.Start();

                frm_1.Content = new Main_Page(frm_1,db);

            }
            catch(SqlException f)
            {
                MessageBox.Show(f.Message);
            }

        }


        //Podwójnym klinknięciem otwieramy Main Page
        private void Main_Page_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Main_Page(frm_1,db);
        }

        //Podwójnym klinknięciem otwieramy Page1 klienci
        private void Druga_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new ClientPage(frm_1,db);

        }    
               

        //Zamykanie programu
        private void Wyjscie_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Czy chcesz zamknąć program?","Uwaga",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            this.Close();
        }
        

        //Wylogowywanie się
        private void _Wyloguj_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Wyloguj(menu1, frm_1);
           // menu.IsEnabled = false;
        }


        //Otwieranie Page Wypozycz
        private void Wypozycz_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page_Wypozycz(db);
        }


        //Otwieranie Page Lista wypożyczen
        private void Lista_Wypozycz_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page_Lista_wypozyczen(db);
        }


        //Otwieranie Page dodawanie klienta
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page_dodaj_klienta(frm_1,db);
        }


        //Otwieranie Page edycja klienta
        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {
            int id_klienta = 0;
            //frm_1.Content = new Page_edytuj_usun_klient( id_klienta, frm_1);
        }

       

        //Otwieranie Page Ksiazki
        private void Ksiazka_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page2(frm_1,db);
        }

        //Otwieranie Page dodawanie ksizaki
        private void Dodaj_ksiazka_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page_dodawanie_ksiazek(frm_1,db);
        }

        

        //Otwieranie Page Edytuj ksiazki
        private void Edytuj_ksiazka_Click(object sender, RoutedEventArgs e)
        {
            int id_ksiazki = 0;
            //frm_1.Content = new Page_edycja_usun_ksiazke( id_ksiazki,frm_1);
        }

        private void Dodaj_autora_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page_dodawanie_autorow(frm_1,db);
        }

        private void Edytuj_autora_Click(object sender, RoutedEventArgs e)
        {
            int id_autora = 0;
            //frm_1.Content = new Page_edycja_usuwanie_autorow(id_autora,frm_1);
        }

        private void Autor_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Autorzy_Page(frm_1,db);
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {

            Color kolorek = new Color(frm_1);
            kolorek.Show();

        }


        


    }
}
