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
    /// Logika interakcji dla klasy Page_dodaj_klienta.xaml
    /// </summary>
    public partial class Page_dodaj_klienta : Page
    {
        SqlConnection conn;
        

        public Page_dodaj_klienta()
        {
            InitializeComponent();
        }

        public Page_dodaj_klienta(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }


        private void Btn_dodaj_kli_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imie = txt_imie.Text;
                string nazwisko = txt_nazwisko.Text;
                string uwaga = "Czy chcesz dodać uzytkownika " + imie + " " + nazwisko + " ?";

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

                    ds.Tables["klienci"].Rows.Add(dr);

                    SqlCommandBuilder sqlbuild = new SqlCommandBuilder(sqlada);
                    sqlada.Update(ds, "klienci");

                    MessageBox.Show("Dodano klienta");
                }

            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
            }


            
        }
    }
}
