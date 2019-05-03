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
    /// Logika interakcji dla klasy Autorzy_Page.xaml
    /// </summary>
    public partial class Autorzy_Page : Page
    {
        Frame frame3;
        SqlConnection conn;
        Klasa_glowna wys_liste;
        string nazwa_tabeli;
       

        public Autorzy_Page()
        {
            InitializeComponent();
        }


        public Autorzy_Page(Frame frame3,SqlConnection conn)
        {
            InitializeComponent();
            this.frame3 = frame3;
            this.conn = conn;

            string polecenie = "select * from autor";
            nazwa_tabeli = "autor";

            wys_liste = new Klasa_glowna();
            wys_liste.ShowWypozyczenia(polecenie, conn, nazwa_tabeli, listView_autorzy);

            lbl_ilosc.Content = listView_autorzy.Items.Count;
        }

        //Przycisk dodawanie autora
        private void Btn_dodaj_autora_Click(object sender, RoutedEventArgs e)
        {
            frame3.Content = new Page_dodawanie_autorow(conn,frame3);
        }

        //Przycisk edycji autora
        private void Btn_edytuj_autora_Click(object sender, RoutedEventArgs e)
        {
            int id_autora = listView_autorzy.SelectedIndex;
            if (id_autora > -1)
            {
                frame3.Content = new Page_edycja_usuwanie_autorow(conn, id_autora,frame3);
            }
            else
            {
                MessageBox.Show("Wybierz autora");
            }
        }

        //Wyszukiwanie autorów
        private void Txt_szukaj_autorow_TextChanged(object sender, TextChangedEventArgs e)
        {
            string dane = txt_szukaj_autorow.Text;
            string polecenie_szukania_autora = " select * from autor where id_autor like'%"+dane+"%' or imie like '%"+dane+"%' or nazwisko like '%"+dane+"%' or(imie + ' ' + nazwisko) like '%"+dane+"%' or(nazwisko + ' ' + imie) like '%"+dane+"%'";

            wys_liste.ShowWypozyczenia(polecenie_szukania_autora, conn, nazwa_tabeli, listView_autorzy);
            lbl_ilosc.Content = listView_autorzy.Items.Count;
        }

        

    }
}
