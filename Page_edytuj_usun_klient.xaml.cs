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
    /// Logika interakcji dla klasy Page_edytuj_usun_klient.xaml
    /// </summary>
    public partial class Page_edytuj_usun_klient : Page
    {
        SqlConnection conn;
        int id_klienta;
        DataSet ds;
        SqlDataAdapter sqlada;
        Frame frame1;
        int iloscslow = 0;

        public Page_edytuj_usun_klient()
        {
            InitializeComponent();
        }

        public Page_edytuj_usun_klient(SqlConnection conn,int id_klienta,Frame frame1 )
        {
            InitializeComponent();
            this.conn = conn;
            this.id_klienta = id_klienta;
            this.frame1 = frame1;

           ds = new DataSet();
            
            string polecenie2 = "select * from klienci";
            sqlada = new SqlDataAdapter(polecenie2, conn);
            sqlada.Fill(ds, "klienci");
            

            txt_imie.Text = ds.Tables["klienci"].Rows[id_klienta][1].ToString();
            txt_nazwisko.Text = ds.Tables["klienci"].Rows[id_klienta][2].ToString();
            txt_nr_tel.Text = ds.Tables["klienci"].Rows[id_klienta][3].ToString();
            txt_uwagi.Text = ds.Tables["klienci"].Rows[id_klienta][5].ToString();
        }


        //Edytowanie klienta
        private void Btn_edytuj_klienta_Click(object sender, RoutedEventArgs e)
        {

            if (id_klienta > -1)
            {
                try
                {
                    ds.Tables["klienci"].Rows[id_klienta][1] = txt_imie.Text;
                    ds.Tables["klienci"].Rows[id_klienta][2] = txt_nazwisko.Text;
                    ds.Tables["klienci"].Rows[id_klienta][3] = txt_nr_tel.Text;
                    ds.Tables["klienci"].Rows[id_klienta][5] = txt_uwagi.Text;

                    SqlCommandBuilder sqlbuilder = new SqlCommandBuilder(sqlada);
                    sqlada.Update(ds, "klienci");

                    MessageBox.Show("Edytowano pomyślnie");
                }
                catch(SqlException f)
                {
                    MessageBox.Show(f.Message);
                }
                catch(FormatException f)
                {
                    MessageBox.Show(f.Message);
                        
                }                
            }
            else
            {
                MessageBox.Show("Musisz wybrać klienta");
            }
        }

        //Usuwanie klienta
        private void Btn_usun_klienta_Click(object sender, RoutedEventArgs e)
        {
            if(id_klienta>-1)
            {
                try
                {
                    string imie = ds.Tables["klienci"].Rows[id_klienta][1].ToString();

                    if (MessageBox.Show("Czy chcesz usuną klienta " + imie + " ?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        ds.Tables["klienci"].Rows[id_klienta].Delete();


                        SqlCommandBuilder sqlbuilder = new SqlCommandBuilder(sqlada);
                        sqlada.Update(ds, "klienci");

                        MessageBox.Show("Usunięto klienta " + imie + "");

                        frame1.Content = new Page1(frame1,conn);
                    }
                }
                catch(SqlException)
                {
                    MessageBox.Show("Nie można usunąć klienta, prawdopodobnie ma wypożyczoną książkę");
                }
            }
        }

        //Powrót
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page1(frame1, conn);
        }

        //Sprawdzanie ile jest znaków w tekscie Uwagi
        private void Txt_uwagi_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
                String slowo = txt_uwagi.Text;
                iloscslow = slowo.Length;
            
            if (iloscslow > 100)
            {
                btn_edytuj_klienta.IsEnabled = false;    
            }
            else
            {
                btn_edytuj_klienta.IsEnabled = true;
            }
           
            String wyrazenie = iloscslow.ToString() + "/100";
            label_ilosc.Content = wyrazenie;
        }

        
    }
}

