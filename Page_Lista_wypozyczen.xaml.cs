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
    /// Logika interakcji dla klasy Page_Lista_wypozyczen.xaml
    /// </summary>
    public partial class Page_Lista_wypozyczen : Page
    {
        SqlConnection conn;
        Klasa_glowna wys_liste;
        string nazwa_tabeli;

        public Page_Lista_wypozyczen()
        {
            InitializeComponent();
        }

        public Page_Lista_wypozyczen(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;


            wys_liste = new Klasa_glowna();
            string polecenielistza = "select   * from wypozyczenia w join klienci k on w.id_klienta = k.id join ksiazki ks on ks.id = w.id_ksiazki";
            nazwa_tabeli = "wypozyczenia ";

            wys_liste.ShowWypozyczenia(polecenielistza, conn, nazwa_tabeli, listViewwypozyczenia1);

        }

        private void Txt_Szukaj_TextChanged(object sender, TextChangedEventArgs e)
        {
            string dane = txt_Szukaj.Text;
            string polecenie_szukania_zamowienia = "select * from wypozyczenia w join klienci k on w.id_klienta = k.id join ksiazki ks on ks.id = w.id_ksiazki where id_wypozyczenia like '%"+dane+"%' or imie like '%"+dane+"%' or nazwisko like '"+dane+"' or(imie + ' ' + nazwisko) like '%"+dane+"%' or tytul like '%"+dane+ "%' or data_zwrotu like '%"+dane+"%' ";
            wys_liste.ShowWypozyczenia(polecenie_szukania_zamowienia, conn, nazwa_tabeli, listViewwypozyczenia1);

        }
    }
}
