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
    /// Logika interakcji dla klasy Page_edycja_usuwanie_autorow.xaml
    /// </summary>
    public partial class Page_edycja_usuwanie_autorow : Page
    {

        SqlConnection conn;
        int id_autora;
        DataSet ds;
        SqlDataAdapter sqlada;
        SqlCommandBuilder sqlbuilder;

        public Page_edycja_usuwanie_autorow()
        {
            InitializeComponent();
        }

        public Page_edycja_usuwanie_autorow(SqlConnection conn,int id_autora)
        {
            InitializeComponent();
            this.conn = conn;
            this.id_autora = id_autora;


            ds = new DataSet();
             string polecenie2 = "select * from autor";
            sqlada = new SqlDataAdapter(polecenie2, conn);
            sqlada.Fill(ds, "autor");

            txt_imie.Text = ds.Tables["autor"].Rows[id_autora][1].ToString();
            txt_nazwisko.Text = ds.Tables["autor"].Rows[id_autora][2].ToString();

        }

        private void Btn_edytuj_autora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ds.Tables["autor"].Rows[id_autora][1] = txt_imie.Text;
                ds.Tables["autor"].Rows[id_autora][2] = txt_nazwisko.Text;

                sqlbuilder = new SqlCommandBuilder(sqlada);
                sqlada.Update(ds, "autor");
                MessageBox.Show("Zedytowano autora " + txt_imie.Text + "");
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

        private void Btn_usun_autora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Czy chcesz usunąć autora " + txt_imie.Text + " ?", "Uwaga!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    ds.Tables["autor"].Rows[id_autora].Delete();

                    sqlbuilder = new SqlCommandBuilder(sqlada);
                    sqlada.Update(ds, "autor");
                    MessageBox.Show("Usunięto autora");
                }
            }
            catch(SqlException )
            {
                MessageBox.Show("Nie można usunąć autora, prawdopodobnie jej/jego książki są w bazie danych ");
            }
        }
    }
}
