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


namespace Biblioteka_system
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn;
       


        public MainWindow()
        {
            InitializeComponent();

            try
            {
                string connString = "Database= Biblioteka;Data Source=localhost; User Id='sa';Password='sasa';";
                conn = new SqlConnection(connString);
                conn.Open();

                
                //frm_1.Content = new Wyloguj(menu1,conn,frm_1);
                frm_1.Content = new Main_Page(frm_1,conn);

            }
            catch(SqlException f)
            {
                MessageBox.Show(f.Message);
            }

        }


        //Podwójnym klinknięciem otwieramy Main Page
        private void Main_Page_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Main_Page(frm_1,conn);
        }

        //Podwójnym klinknięciem otwieramy Page1 klienci
        private void Druga_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page1(frm_1,conn);

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
            frm_1.Content = new Wyloguj(menu1, conn, frm_1);
           // menu.IsEnabled = false;
        }


        //Otwieranie Page Wypozycz
        private void Wypozycz_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page_Wypozycz(conn);
        }


        //Otwieranie Page Lista wypożyczen
        private void Lista_Wypozycz_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page_Lista_wypozyczen(conn);
        }


        //Otwieranie Page dodawanie klienta
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page_dodaj_klienta(conn,frm_1);
        }


        //Otwieranie Page edycja klienta
        private void Edytuj_Click(object sender, RoutedEventArgs e)
        {
            int id_klienta = 0;
            frm_1.Content = new Page_edytuj_usun_klient(conn, id_klienta, frm_1);
        }

       

        //Otwieranie Page Ksiazki
        private void Ksiazka_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page2(frm_1,conn);
        }

        //Otwieranie Page dodawanie ksizaki
        private void Dodaj_ksiazka_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page_dodawanie_ksiazek(conn,frm_1);
        }

        

        //Otwieranie Page Edytuj ksiazki
        private void Edytuj_ksiazka_Click(object sender, RoutedEventArgs e)
        {
            int id_ksiazki = 0;
            frm_1.Content = new Page_edycja_usun_ksiazke(conn, id_ksiazki,frm_1);
        }

        private void Dodaj_autora_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Page_dodawanie_autorow(conn,frm_1);
        }

        private void Edytuj_autora_Click(object sender, RoutedEventArgs e)
        {
            int id_autora = 0;
            frm_1.Content = new Page_edycja_usuwanie_autorow(conn,id_autora,frm_1);
        }

        private void Autor_Click(object sender, RoutedEventArgs e)
        {
            frm_1.Content = new Autorzy_Page(frm_1, conn);
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {

            Color kolorek = new Color(frm_1);
            kolorek.Show();


        }


        


    }
}
