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
    /// Logika interakcji dla klasy Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        Frame frame2;
        SqlConnection conn;
        Klasa_glowna wys_liste;
        string nazwa_tabeli;
        string polecenie;

        public Page2()
        {
            InitializeComponent();
        }

        public Page2(Frame frame2,SqlConnection conn)
        {
            InitializeComponent();
            this.frame2 = frame2;
            this.conn = conn;

            polecenie = "select *, (imie+' '+nazwisko) as imieNazwisko from ksiazki k join autorzyKsiazki ak on ak.id_aksiazki = k.idksiazki join autor a on a.id_autor = ak.id_autor order by 1 ";
            polecenie = "select * from ksiazki";
            nazwa_tabeli = "ksiazki";

            wys_liste = new Klasa_glowna();
            wys_liste.ShowWypozyczenia(polecenie, conn, nazwa_tabeli, listView_ksiazka);

            lbl_ilosc.Content = listView_ksiazka.Items.Count;

            //listView_ksiazka.UpdateLayout();
        }

        //Przycisk dodawanie ksiazek
        private void Btn_dodaj_ksiazke_Click(object sender, RoutedEventArgs e)
        {
            frame2.Content = new Page_dodawanie_ksiazek(conn,frame2);
        }

        //Przycisk edycji ksiazek
        private void Btn_edytuj_ksiazke_Click(object sender, RoutedEventArgs e)
        {
            int id_ksiazki = listView_ksiazka.SelectedIndex;
            if (id_ksiazki > -1)
            {
                
                frame2.Content = new Page_edycja_usun_ksiazke(conn,id_ksiazki,frame2);
            }
            else
            {
                MessageBox.Show("Muisz wybrać książkę","Uwaga");
            }
        }

        //Wyszukiwanie ksiazek
        private void Txt_szukaj_ksiazke_TextChanged(object sender, TextChangedEventArgs e)
        {
            string dane = txt_szukaj_ksiazke.Text;

            string polecenie_szukania_ksiazki = "select *, (imie+' '+nazwisko) as imieNazwisko from ksiazki k join autorzyKsiazki ak on ak.id_aksiazki = k.idksiazki join autor a on a.id_autor = ak.id_autor where idksiazki like '%" + dane+"%' or tytul like '%"+dane+"%' or imie like '%"+dane+"%' or nazwisko like '"+dane+"' or(imie + ' ' + nazwisko) like '%"+dane+ "%' order by 1 ";
            wys_liste.ShowWypozyczenia(polecenie_szukania_ksiazki, conn, nazwa_tabeli, listView_ksiazka);

            lbl_ilosc.Content = listView_ksiazka.Items.Count;
        }

        //Przycisk dodawanie wspolautora
        private void Btn_kolejny_autor_Click(object sender, RoutedEventArgs e)
        {
            int index_ksiazki = listView_ksiazka.SelectedIndex;
            if (index_ksiazki>-1)
            {

                DataTable KlienciTable = new DataTable();
                //string polecenie_klienci = "select * from ksiazki";
                 SqlDataAdapter sqladapter = new SqlDataAdapter(polecenie, conn);
                sqladapter.Fill(KlienciTable);


                string tytul = KlienciTable.Rows[index_ksiazki][1].ToString();
                string id_ksiazki = KlienciTable.Rows[index_ksiazki][0].ToString();

                Okno_dodaj_wspolautora okno = new Okno_dodaj_wspolautora(conn, frame2,tytul, id_ksiazki);
                okno.Show();
            }
            else
            {
                MessageBox.Show("Muisz wybrać książkę","Uwaga");
            }


        }
    }
}
