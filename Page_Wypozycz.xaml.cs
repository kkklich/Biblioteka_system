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
    /// Logika interakcji dla klasy Page_Wypozycz.xaml
    /// </summary>
    public partial class Page_Wypozycz : Page
    {
        SqlConnection conn;
        Klasa_glowna wys_liste;
        string nazwa_tabeli_ksiazki;
        string nazwa_tabeli_klient;

        public Page_Wypozycz()
        {
            InitializeComponent();
        }

        public Page_Wypozycz(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;

            wys_liste = new Klasa_glowna();

            string polecenie_klient = "select * from klienci";
            nazwa_tabeli_klient = "klienci";

            wys_liste.ShowWypozyczenia(polecenie_klient, conn, nazwa_tabeli_klient, Listview_Klienci);

            string polecenie_ksaizka = "select *, (imie+' '+nazwisko) as imieNazwisko from ksiazki k join autorzyKsiazki ak on ak.id_aksiazki = k.id join autor a on a.id_autor = ak.id_autor ";
            nazwa_tabeli_ksiazki = "ksiazki";

            wys_liste.ShowWypozyczenia(polecenie_ksaizka, conn, nazwa_tabeli_ksiazki, Listview_Ksiazki);

            
        }

        private void Txt_szukaj_klientow_TextChanged(object sender, TextChangedEventArgs e)
        {
            string dane = txt_szukaj_klientow.Text;
            string polecenie_szukania_klienta = "select * from klienci where id like '%" + dane + "%' or imie like '%" + dane + "%' or nazwisko like '%" + dane + "%' or numer_telefonu like '%" + dane + "%' or (imie+' '+nazwisko) like '%" + dane + "%' ";
            wys_liste.ShowWypozyczenia(polecenie_szukania_klienta, conn, nazwa_tabeli_klient, Listview_Klienci);
        }

        private void Txt_szukaj_ksiazki_TextChanged(object sender, TextChangedEventArgs e)
        {
            string dane = txt_szukaj_ksiazki.Text;

            string polecenie_szukania_ksiazki = "select *, (imie+' '+nazwisko) as imieNazwisko from ksiazki k join autorzyKsiazki ak on ak.id_aksiazki = k.id join autor a on a.id_autor = ak.id_autor where id like '%" + dane + "%' or tytul like '%" + dane + "%' or imie like '%" + dane + "%' or nazwisko like '" + dane + "' or(imie + ' ' + nazwisko) like '%" + dane + "%' ";
            wys_liste.ShowWypozyczenia(polecenie_szukania_ksiazki, conn, nazwa_tabeli_ksiazki, Listview_Ksiazki);
        }
    }
}
