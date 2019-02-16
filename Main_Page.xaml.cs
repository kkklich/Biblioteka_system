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
using System.Data;
using System.Data.SqlClient;


namespace Biblioteka_system
{
    /// <summary>
    /// Logika interakcji dla klasy Main_Page.xaml
    /// </summary>
    public partial class Main_Page : Page
    {
        Frame frame1;
        SqlConnection conn;
        


        public Main_Page()
        {
            InitializeComponent();
        }

        public Main_Page( Frame frame1,SqlConnection conn)
        {
            InitializeComponent();

            this.frame1 = frame1;
            this.conn = conn;
        }

    

        //Otwieranie page klienci
        private void Btn_klient_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page1(frame1,conn);
        }

        private void Btn_ksiazki_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page2(frame1,conn);
        }

        private void Btn_autorzy_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Autorzy_Page(frame1,conn);
        }

        private void Btn_wypozycz_Copy_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page_Wypozycz(conn);
        }

        private void Btn_lista_wypozyczen_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page_Lista_wypozyczen(conn);
        }


        



    }
}
