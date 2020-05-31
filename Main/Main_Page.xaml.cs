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
using System.Runtime.Remoting.Contexts;
using Biblioteka_system.Client;

namespace Biblioteka_system.Main
{
    /// <summary>
    /// Logika interakcji dla klasy Main_Page.xaml
    /// </summary>
    public partial class Main_Page : Page
    {
        Frame frame1;
        BibliotekaEntities db;


        public Main_Page()
        {
            InitializeComponent();
        }

        public Main_Page( Frame frame1,BibliotekaEntities db)
        {
            InitializeComponent();

            this.frame1 = frame1;
            this.db = db;
            
        }

    

        //Otwieranie page klienci
        private void Btn_klient_Click(object sender, RoutedEventArgs e)
        {
            
            frame1.Content = new ClientPage(frame1,db);
        }

        private void Btn_ksiazki_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page2(frame1,db);
        }

        private void Btn_autorzy_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Autorzy_Page(frame1,db);
        }

        private void Btn_wypozycz_Copy_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page_Wypozycz(db);
        }

        private void Btn_lista_wypozyczen_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page_Lista_wypozyczen(db);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            WindowView windowView1 = new WindowView();
            windowView1.Show();


        }
    }
}
