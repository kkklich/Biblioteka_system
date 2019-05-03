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
        Boolean wys = true;
        string polecenielistza;
        DataSet ds;
        SqlDataAdapter sqlAdapterWypo;
        String polecenietermin;
        String polecenie1;
        String data;
        String polecenietermin2;


        public Page_Lista_wypozyczen()
        {
            InitializeComponent();
        }

        public Page_Lista_wypozyczen(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;

            
            wys_liste = new Klasa_glowna();
            polecenielistza = "select * from wypozyczenia w join klienci k on k.idklient = w.id_klienta join autorzyksiazki ak on ak.id_ak = w.id_ak join ksiazki ks on ks.idksiazki = ak.id_aksiazki";
            polecenie1 = "select * from wypozyczenia";
            nazwa_tabeli = "wypozyczenia";



            //wys_liste.ShowWypozyczenia(polecenielistza, conn, nazwa_tabeli, listViewwypozyczenia1);
            //lbl_ilosc.Content = listViewwypozyczenia1.Items.Count.ToString();

            zmianalist(polecenielistza);

            DateTime teraz = DateTime.Now;
            string dzien = teraz.Day.ToString();
            string miesiac = teraz.Month.ToString();
            string rok = teraz.Year.ToString();

            data = rok + "-" + miesiac + "-" + dzien;
            polecenietermin = "select * from wypozyczenia w join klienci k on k.idklient = w.id_klienta join autorzyksiazki ak on ak.id_ak = w.id_ak join ksiazki ks on ks.idksiazki = ak.id_aksiazki where w.data_zwrotu < '" + data + "'";
            polecenietermin2 = "select  * from wypozyczenia where data_zwrotu < '" + data + "'";

        }


        //Wyszukiwanie spośrod zamówień
        private void Txt_Szukaj_TextChanged(object sender, TextChangedEventArgs e)
        {
            string dane = txt_Szukaj.Text;
            string polecenie_szukania_zamowienia;
            if (wys == true)
            {
                 polecenie_szukania_zamowienia = "select * from wypozyczenia w join klienci k on k.idklient = w.id_klienta join autorzyksiazki ak on ak.id_ak = w.id_ak join ksiazki ks on ks.idksiazki = ak.id_aksiazki where id_wypozyczenia like '%" + dane + "%' or imie like '%" + dane + "%' or nazwisko like '" + dane + "' or(imie + ' ' + nazwisko) like '%" + dane + "%' or tytul like '%" + dane + "%' or data_zwrotu like '%" + dane + "%' ";
                
            }
            else
            {
                polecenie_szukania_zamowienia = "select * from wypozyczenia w join klienci k on k.idklient = w.id_klienta join autorzyksiazki ak on ak.id_ak = w.id_ak join ksiazki ks on ks.idksiazki = ak.id_aksiazki where w.data_zwrotu < '" + data+"' and (id_wypozyczenia like '%" + dane + "%' or imie like '%" + dane + "%' or nazwisko like '" + dane + "' or(imie + ' ' + nazwisko) like '%" + dane + "%' or tytul like '%" + dane + "%' or data_zwrotu like '%" + dane + "%' )";
            }

            //wys_liste.ShowWypozyczenia(polecenie_szukania_zamowienia, conn, nazwa_tabeli, listViewwypozyczenia1);
            //lbl_ilosc.Content = listViewwypozyczenia1.Items.Count.ToString();

            zmianalist(polecenie_szukania_zamowienia);
        }


        //Zamykanie wypożyczenia
        private void Btn_zamknij_wyp_Click(object sender, RoutedEventArgs e)
        {


            int indexwyp = listViewwypozyczenia1.SelectedIndex;


            try
            {
                if (indexwyp > -1)
                {
                    SqlCommandBuilder SqlBuilderWyp;
                    string slowo;

                    if (MessageBox.Show("Czy chcesz zamknąć wypożyczenie ? ", "Uwaga", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {

                        if (wys == true)
                        {
                            datas(polecenie1);

                            slowo = polecenielistza;
                            //ds.Tables[nazwa_tabeli].Rows[indexwyp].Delete();
                            //SqlBuilderWyp = new SqlCommandBuilder(sqlAdapterWypo);
                            //sqlAdapterWypo.Update(ds, nazwa_tabeli);


                            //wys_liste.ShowWypozyczenia(polecenielistza, conn, nazwa_tabeli, listViewwypozyczenia1);

                            //ShowWypozyczenia(polecenie2);
                        }
                        else
                        {

                            datas(polecenietermin2);
                            slowo = polecenietermin;
                        }


                        ds.Tables[nazwa_tabeli].Rows[indexwyp].Delete();
                            SqlBuilderWyp = new SqlCommandBuilder(sqlAdapterWypo);
                            sqlAdapterWypo.Update(ds, nazwa_tabeli);

                            zmianalist(slowo);
                           // wys_liste.ShowWypozyczenia(polecenietermin, conn, nazwa_tabeli, listViewwypozyczenia1);
                        

                    }
                }
                else
                {
                    MessageBox.Show("Musisz wybrać wypożyczenie", "Uwaga");
                }


            }
            catch (SqlException f)
            {
                MessageBox.Show(f.Message);
            }


        }


        //Zamówienia przeterminowane
        private void Btn_over_Click(object sender, RoutedEventArgs e)
        {
            if (wys == true)
            {
                //wys_liste.ShowWypozyczenia(polecenietermin, conn, nazwa_tabeli, listViewwypozyczenia1);
                //lbl_ilosc.Content = listViewwypozyczenia1.Items.Count.ToString();
                zmianalist(polecenietermin);

                wys = false;

                btn_over.Content = "Wyświetl wszystkie wyp ";
                lbl_info.Content = "Zamówienia przeterminowane";
            }
            else
            {

                //wys_liste.ShowWypozyczenia(polecenielistza, conn, nazwa_tabeli, listViewwypozyczenia1);
                //lbl_ilosc.Content = listViewwypozyczenia1.Items.Count.ToString();
                zmianalist(polecenielistza);

                wys = true;

                btn_over.Content = "Wypożyczenia przeterminowane";
                lbl_info.Content = "Wszystkie zamówienia";

            }
        }


        //funkcja zmiany listview
        private void zmianalist(string polecenie)
        {
            string polec = polecenie;
            wys_liste.ShowWypozyczenia(polec, conn, nazwa_tabeli, listViewwypozyczenia1);
            lbl_ilosc.Content = listViewwypozyczenia1.Items.Count.ToString();
        }


        //Przedłużanie wypozyczenia
        private void Btn_upadte_Click(object sender, RoutedEventArgs e)
        {



            int indexwyp = listViewwypozyczenia1.SelectedIndex;

            if (indexwyp > -1)
            {
                DateTime newtime = DateTime.Now;
                String pol;

                if (wys == true)
                {

                    

                    datas(polecenie1);
                    pol = polecenielistza;

                }
                else
                {

                    DateTime teraz = DateTime.Now;
                    string dzien = teraz.Day.ToString();
                    string miesiac = teraz.Month.ToString();
                    string rok = teraz.Year.ToString();

                    String data = rok + "-" + miesiac + "-" + dzien;

                    

                    datas(polecenietermin2);

                    pol = polecenietermin;
                }

                    DateTime.TryParse(ds.Tables[nazwa_tabeli].Rows[indexwyp]["data_zwrotu"].ToString(), out newtime);
                    newtime = newtime.AddDays(30);

                    ds.Tables[nazwa_tabeli].Rows[indexwyp]["data_zwrotu"] = newtime;
                    SqlCommandBuilder SqlBuilderWyp = new SqlCommandBuilder(sqlAdapterWypo);
                    sqlAdapterWypo.Update(ds, nazwa_tabeli);

                zmianalist(pol);
                    
                    
                
            }

        }



        //funkcja dataset
        private void datas(string polecenie)
        {
             ds = new DataSet();
            string polecenieDS = polecenie;
            sqlAdapterWypo = new SqlDataAdapter(polecenieDS, conn);
            sqlAdapterWypo.Fill(ds, nazwa_tabeli);

        }

        //Wyswietlanie szczegółów
        private void Btn_szczegoly_Click(object sender, RoutedEventArgs e)
        {
            int numer = listViewwypozyczenia1.SelectedIndex;
            if (numer > -1)
            {


                if (wys == true)
                {
                    datas(polecenielistza);
                    Szczegoly okno = new Szczegoly(numer, ds, conn, polecenielistza);
                    okno.Show();

                }
                else
                {
                    DateTime teraz = DateTime.Now;
                    string dzien = teraz.Day.ToString();
                    string miesiac = teraz.Month.ToString();
                    string rok = teraz.Year.ToString();

                    String data = rok + "-" + miesiac + "-" + dzien;

                    polecenietermin = "select * from wypozyczenia w join klienci k on k.idklient = w.id_klienta join autorzyksiazki ak on ak.id_ak = w.id_ak join ksiazki ks on ks.idksiazki = ak.id_aksiazki where w.data_zwrotu < '" + data + "'";

                    datas(polecenietermin);
                    Szczegoly okno = new Szczegoly(numer, ds, conn, polecenietermin);
                    okno.Show();

                }
            }
            else
            {
                MessageBox.Show("Musisz wybrać wypożyczenie");
            }
        }

       
    }
}
