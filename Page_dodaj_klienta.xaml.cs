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
using System.Text.RegularExpressions;

namespace Biblioteka_system
{
    /// <summary>
    /// Logika interakcji dla klasy Page_dodaj_klienta.xaml
    /// </summary>
    public partial class Page_dodaj_klienta : Page
    {
        SqlConnection conn;
        Frame frame1;

        public Page_dodaj_klienta()
        {
            InitializeComponent();
        }

        public Page_dodaj_klienta(SqlConnection conn,Frame frame1)
        {
            InitializeComponent();
            this.conn = conn;
            this.frame1 = frame1;
        }


        //Przycisk dodawanie klienta
        private void Btn_dodaj_kli_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imie = txt_imie.Text;
                string nazwisko = txt_nazwisko.Text;
                string uwaga = "Czy chcesz dodać uzytkownika " + imie + " " + nazwisko + " ?";

                if (txt_imie.Text != "" && txt_nazwisko.Text != "" && txt_nr_tel.Text != "")
                {

                    if (MessageBox.Show(uwaga, "Uwaga", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        DataSet ds = new DataSet();
                        string polcenie = "select * from klienci";
                        SqlDataAdapter sqlada = new SqlDataAdapter(polcenie, conn);
                        sqlada.Fill(ds, "klienci");
                        DataRow dr = ds.Tables["klienci"].NewRow();


                        dr["imie"] = txt_imie.Text;
                        dr["nazwisko"] = txt_nazwisko.Text;
                        dr["numer_telefonu"] = txt_nr_tel.Text;
                        dr["uwagi"] = txt_uwagi.Text;

                        ds.Tables["klienci"].Rows.Add(dr);

                        SqlCommandBuilder sqlbuild = new SqlCommandBuilder(sqlada);
                        sqlada.Update(ds, "klienci");

                        MessageBox.Show("Dodano klienta");
                    }
                }
                else
                {
                    MessageBox.Show("Nie wszystkie pola są wypełnione ");
                }
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
            }


            
        }

        //Powrót
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            frame1.Content = new Page1(frame1, conn);

        }

        //Sprawdzanie poprawności nr telefonu
        private void Txt_nr_tel_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");

            if (txt_nr_tel.Text.Length == 9 && regex.IsMatch(txt_nr_tel.Text))
            {
                btn_dodaj_kli.IsEnabled = true;
            }
            else
            {
                btn_dodaj_kli.IsEnabled = false;
            }   
        }

        private void Txt_uwagi_TextChanged(object sender, TextChangedEventArgs e)
        {

            String slowo = txt_uwagi.Text;
            int iloscslow = slowo.Length;

            if (iloscslow > 100)
            {
                btn_dodaj_kli.IsEnabled = false;
            }
            else
            {
                btn_dodaj_kli.IsEnabled = true;
            }

            String wyrazenie = iloscslow.ToString() + "/100";
            label_ilosc.Content = wyrazenie;
        }
    }
}
