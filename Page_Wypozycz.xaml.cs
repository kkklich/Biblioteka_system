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
    /// 


    public class wypozyczenia
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string ksiazka { get; set; }

    }

    public partial class Page_Wypozycz : Page
    {
        SqlConnection conn;
        Klasa_glowna wys_liste;
        string nazwa_tabeli_ksiazki;
        string nazwa_tabeli_klient;
        DataSet ds;
        SqlDataAdapter sqladapter;
        DataTable tabelaZam;
            string tytul_ksiazki;
        string id_ksiazki;
        string id_klienta;
        DateTime dataoddania;
        DateTime datadzis;
        SqlCommandBuilder sqlbuilder;
        bool istnienieTEMP = false;
        DataTable TEMPtabela;
        DataTable KlienciTable;
        int klikniecia_zamow = 0;


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


        //Przycisk Zamów
        private void Btn_zamów_Click(object sender, RoutedEventArgs e)
        {
                int index_klienta = Listview_Klienci.SelectedIndex;
                int index_ksiazki = Listview_Ksiazki.SelectedIndex;

            try { 
                if (index_klienta > -1 & index_ksiazki > -1)
                {
                    datadzis = DateTime.Now;
                    dataoddania = datadzis.AddDays(30);



                    KlienciTable = new DataTable();
                    string polecenie_klienci = "select * from klienci";
                    sqladapter = new SqlDataAdapter(polecenie_klienci, conn);
                    sqladapter.Fill(KlienciTable);


                    id_klienta = KlienciTable.Rows[index_klienta][0].ToString();

                    string imie_klienta = KlienciTable.Rows[index_klienta][1].ToString();
                    string nazwisko_klienta = KlienciTable.Rows[index_klienta][2].ToString();


                    KlienciTable = new DataTable();
                    string polecenie_ksiaki = "select *, (imie+' '+nazwisko) as imieNazwisko from ksiazki k join autorzyKsiazki ak on ak.id_aksiazki = k.id join autor a on a.id_autor = ak.id_autor ";
                    sqladapter = new SqlDataAdapter(polecenie_ksiaki, conn);
                    sqladapter.Fill(KlienciTable);
                    id_ksiazki = KlienciTable.Rows[index_ksiazki]["id"].ToString();

                    tytul_ksiazki = KlienciTable.Rows[index_ksiazki][1].ToString();

                    Listview_zamowienia.Items.Add(new wypozyczenia() { imie = imie_klienta, nazwisko = nazwisko_klienta, ksiazka = tytul_ksiazki });




                    TworzenieTEMP();
                }
            }
            catch(SqlException )
            {
                TEMPtabela = new DataTable();
                string usuwanieTEMP = "drop table TEMP";
                sqladapter = new SqlDataAdapter(usuwanieTEMP, conn);
                sqladapter.Fill(TEMPtabela);

                istnienieTEMP = false;



                TworzenieTEMP();




                //MessageBox.Show(f.Message);
            }
            catch (FormatException f)
            {
                MessageBox.Show(f.Message);
            }


        }





        private void TworzenieTEMP()
        {

            if (istnienieTEMP == false)
            {
                TEMPtabela = new DataTable();
                string tworzenieTEMP = "create table TEMP( id_temp int primary key identity not null, id_klienta int foreign key references klienci(id), id_ksiazki int foreign key references ksiazki(id), data_wypozyczenia date not null, data_zwrotu date not null )";
                sqladapter = new SqlDataAdapter(tworzenieTEMP, conn);
                sqladapter.Fill(TEMPtabela);

                istnienieTEMP = true;
            }

            TEMPtabela = new DataTable();

            string polecenie = "select * from TEMP";
            sqladapter = new SqlDataAdapter(polecenie, conn);
            sqladapter.Fill(TEMPtabela);

            DataRow dr = TEMPtabela.NewRow();

            dr["id_klienta"] = id_klienta;
            dr["id_ksiazki"] = id_ksiazki;
            dr["data_wypozyczenia"] = datadzis;
            dr["data_zwrotu"] = dataoddania;

            TEMPtabela.Rows.Add(dr);

            sqlbuilder = new SqlCommandBuilder(sqladapter);
            sqladapter.Update(TEMPtabela);

        }


        private void Btn_Wypozycz_Film_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (istnienieTEMP == true)
                {

                    int ilosc = TEMPtabela.Rows.Count;
                    MessageBox.Show(ilosc.ToString());
                    string dataobecna, datazwrotu;

                    for (int i = 0; i < ilosc; i++)
                    {



                        id_klienta = TEMPtabela.Rows[i]["id_klienta"].ToString();
                        id_ksiazki = TEMPtabela.Rows[i]["id_ksiazki"].ToString();
                        dataobecna = TEMPtabela.Rows[i]["data_wypozyczenia"].ToString();
                        datazwrotu = TEMPtabela.Rows[i]["data_zwrotu"].ToString();


                        datadzis = DateTime.Parse(dataobecna);
                        dataoddania = DateTime.Parse(datazwrotu);

                        ds = new DataSet();

                        string polecenie_wyp = "select * from wypozyczenia";
                        sqladapter = new SqlDataAdapter(polecenie_wyp, conn);
                        sqladapter.Fill(ds, "wypozyczenia");
                        DataRow dr = ds.Tables["wypozyczenia"].NewRow();

                        dr["id_klienta"] = id_klienta;
                        dr["id_ksiazki"] = id_ksiazki;
                        dr["data_wypozyczenia"] = datadzis;
                        dr["data_zwrotu"] = dataoddania;

                        ds.Tables["wypozyczenia"].Rows.Add(dr);




                        SqlCommandBuilder sqlbuilder = new SqlCommandBuilder(sqladapter);
                        sqladapter.Update(ds, "wypozyczenia");
                    }


                    TEMPtabela = new DataTable();
                    string usuwanieTEMP = "drop table TEMP";
                    sqladapter = new SqlDataAdapter(usuwanieTEMP, conn);
                    sqladapter.Fill(TEMPtabela);

                    istnienieTEMP = false;
                }
                else
                {
                    MessageBox.Show("Musisz wybrać zamówienie");
                }


            }
            catch(SqlException f)
            {
                MessageBox.Show(f.Message);

            }
            
        }
    }
}
