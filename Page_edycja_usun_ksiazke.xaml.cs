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
    /// Logika interakcji dla klasy Page_edycja_usun_ksiazke.xaml
    /// </summary>
    public partial class Page_edycja_usun_ksiazke : Page
    {
        SqlConnection conn;
        int id_ksiazki;
        DataSet ds;
        SqlDataAdapter sqlada;

        public Page_edycja_usun_ksiazke()
        {
            InitializeComponent();
        }

        public Page_edycja_usun_ksiazke(SqlConnection conn,int id_ksiazki)
        {
            InitializeComponent();
            this.conn = conn;
            this.id_ksiazki = id_ksiazki;


           ds = new DataSet();
            
            string polecenie2 = "select *, (imie+' '+nazwisko) as imieNazwisko from ksiazki k join autorzyKsiazki ak on ak.id_aksiazki = k.id join autor a on a.id_autor = ak.id_autor ";
            sqlada = new SqlDataAdapter(polecenie2, conn);
            sqlada.Fill(ds, "ksiazki");

            txt_tytul.Text = ds.Tables["ksiazki"].Rows[id_ksiazki][1].ToString();
            txt_autor.Text = ds.Tables["ksiazki"].Rows[id_ksiazki][7].ToString();

        }

        private void Btn_edytuj_ksiazke_Click(object sender, RoutedEventArgs e)
        {

            //ds.Tables["ksiazki"]


        }
    }
}
