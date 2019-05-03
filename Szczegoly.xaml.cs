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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteka_system
{
    /// <summary>
    /// Logika interakcji dla klasy Szczegoly.xaml
    /// </summary>
    public partial class Szczegoly : Window
    {
        int numer, ile = 0;
        DataSet ds;
        SqlConnection conn;
        string polecenieDS;
        Klasa_glowna wyswietl;

        public Szczegoly()
        {
            InitializeComponent();
        }

        public Szczegoly(int nr, DataSet ds, SqlConnection conn, string polecenie)
        {
            InitializeComponent();

            numer = nr;
            this.ds = ds;
            this.conn = conn;
            polecenieDS = polecenie;

            wyswietl = new Klasa_glowna();

            showWyp();
        }

        //Przesuwanie danych klientow w lewo
        private void Btn_left_Click(object sender, RoutedEventArgs e)
        {
            if (numer >= 1 & numer < ile)
            {
                numer--;
                showWyp();
            }
        }

        //Przesuwanie danych klientow w prawo
        private void Btn_right_Click(object sender, RoutedEventArgs e)
        {
            if (numer < ile - 1 & numer >= 0)
            {
                numer++;
                showWyp();
            }
        }

        //Zamykanie okno szczegoly
        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Funkcja wyswitlajaca dane szczegolowe w polach tekstowych
        void showWyp()
        {

            ds = new DataSet();

            SqlDataAdapter sqlAdapterWypo = new SqlDataAdapter(polecenieDS, conn);
            sqlAdapterWypo.Fill(ds, "wypozyczenia");


            txt_ID.Text = ds.Tables["wypozyczenia"].Rows[numer]["id_wypozyczenia"].ToString();
            txt_imie.Text = ds.Tables["wypozyczenia"].Rows[numer]["imie"].ToString();
            txt_Nazwisko.Text = ds.Tables["Wypozyczenia"].Rows[numer]["nazwisko"].ToString();
            txt_Nrtel.Text = ds.Tables["Wypozyczenia"].Rows[numer]["numer_telefonu"].ToString();
            txt_DataWypoz.Text = ds.Tables["Wypozyczenia"].Rows[numer]["data_wypozyczenia"].ToString();
            txt_DataZwrotu.Text = ds.Tables["Wypozyczenia"].Rows[numer]["data_zwrotu"].ToString();
            txt_tytulFilmu.Text = ds.Tables["Wypozyczenia"].Rows[numer]["tytul"].ToString();
           

            ile = ds.Tables["Wypozyczenia"].Rows.Count;

        }


    }
}
