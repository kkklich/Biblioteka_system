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
    /// Logika interakcji dla klasy Page_dodawanie_autorow.xaml
    /// </summary>
    public partial class Page_dodawanie_autorow : Page
    {
        SqlConnection conn;

        public Page_dodawanie_autorow()
        {
            InitializeComponent();
        }
        public Page_dodawanie_autorow(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;

        }

        private void Btn_dodaj_autora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imie = txt_imie.Text;
                string nazwisko = txt_nazwisko.Text;
                string uwaga = "Czy chcesz dodać autora " + imie + " " + nazwisko + " ?";

                if (MessageBox.Show(uwaga, "Uwaga", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DataSet ds = new DataSet();
                    string polcenie = "select * from autor";
                    SqlDataAdapter sqlada = new SqlDataAdapter(polcenie, conn);
                    sqlada.Fill(ds, "autor");
                    DataRow dr = ds.Tables["autor"].NewRow();


                    dr["imie"] = txt_imie.Text;
                    dr["nazwisko"] = txt_nazwisko.Text;


                    ds.Tables["autor"].Rows.Add(dr);

                    SqlCommandBuilder sqlbuild = new SqlCommandBuilder(sqlada);
                    sqlada.Update(ds, "autor");

                    MessageBox.Show("Dodano autora");

                    
                }

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }
    }
}
