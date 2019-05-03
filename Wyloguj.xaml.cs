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
using System.Data.SqlClient;
using System.Data;


namespace Biblioteka_system
{
    /// <summary>
    /// Logika interakcji dla klasy Wyloguj.xaml
    /// </summary>
    public partial class Wyloguj : Page
    {
        Menu menu1;
        SqlConnection conn;
        DataSet ds;
        Frame frm1;

        public Wyloguj()
        {
            InitializeComponent();
        }

        public Wyloguj(Menu menu1,SqlConnection conn,Frame frm)
        {
            InitializeComponent();
            this.menu1 = menu1;
            this.conn = conn;
            this.frm1 = frm;
            menu1.IsEnabled = false;
        }

        private void Btn_loguj_Click(object sender, RoutedEventArgs e)
        {
            ds = new DataSet();
            String poleceniePrac = "select * from pracownicy";

            SqlDataAdapter sqladapter = new SqlDataAdapter(poleceniePrac, conn);
            sqladapter.Fill(ds, "pracownicy");

            int ilosc = ds.Tables["pracownicy"].Rows.Count;
            Boolean czyjestPracownik = false;

            for (int i = 0; i < ilosc; i++)
            {
                String imie = ds.Tables["pracownicy"].Rows[i]["imie"].ToString();
                String nazwisko = ds.Tables["pracownicy"].Rows[i]["nazwisko"].ToString();
                if (txt_imie.Text == imie && txt_nazwisko.Text == nazwisko)
                {
                    frm1.Content = new Main_Page(frm1, conn);
                    menu1.IsEnabled = true;
                    czyjestPracownik = true;
                    break;
                }
                else
                {
                    czyjestPracownik = false;
                }

            }

            if(czyjestPracownik==false)
            {
                MessageBox.Show("Nie ma takiego pracownika");
            }
        }
    }
}
