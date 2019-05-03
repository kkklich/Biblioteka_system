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
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Frame frame1;
        SqlConnection conn;
        Klasa_glowna wys_liste = new Klasa_glowna();
        string nazwa_tabeli = "klienci";



        public Page1()
        {
            InitializeComponent();
            
        }

        public Page1(Frame frame1,SqlConnection conn)
        {
            InitializeComponent();
            this.frame1 = frame1;
            this.conn = conn;

            string polecenie = "select * from klienci";

            wys_liste.ShowWypozyczenia(polecenie, conn, nazwa_tabeli, listView);

            lbl_ilosc.Content = listView.Items.Count;
        }

            //Dodawanie klientow
        private void Btn_dodaj_klienta_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page_dodaj_klienta(conn,frame1);
        }

        //Edycja klientow
        private void Btn_edytuj_klienta_Click(object sender, RoutedEventArgs e)
        {
            int id_selected = listView.SelectedIndex;
            if (id_selected > -1)
            {
                frame1.Content = new Page_edytuj_usun_klient(conn, id_selected,frame1);
            }
            else
            {
                MessageBox.Show("Musisz wybrać klienta");
            }
        }

        //Wyszukiwanie klientow
        private void Txt_szukaj_TextChanged(object sender, TextChangedEventArgs e)
        {
            string dane = txt_szukaj.Text;

            string polecenie_szukania_klienta = "select * from klienci where idklient like '%" + dane+"%' or imie like '%"+dane+"%' or nazwisko like '%"+dane+"%' or numer_telefonu like '%"+dane + "%' or (imie+' '+nazwisko) like '%"+dane+"%' ";
            wys_liste.ShowWypozyczenia(polecenie_szukania_klienta, conn, nazwa_tabeli, listView);
            lbl_ilosc.Content = listView.Items.Count;
        }
    }
}
