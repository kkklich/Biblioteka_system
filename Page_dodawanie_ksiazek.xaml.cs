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
    /// Logika interakcji dla klasy Page_dodawanie_ksiazek.xaml
    /// </summary>
    public partial class Page_dodawanie_ksiazek : Page
    {

        SqlConnection conn;
        SqlDataAdapter sqlada;
        DataSet ds;
        Frame frame1;

        string id_ksiazki;

        public Page_dodawanie_ksiazek()
        {
            InitializeComponent();
        }


        public Page_dodawanie_ksiazek(SqlConnection conn,Frame frame1)
        {
            InitializeComponent();
            this.conn = conn;
            this.frame1 = frame1;

            
            string polecenie_autor = "select *, (imie+' '+nazwisko) as imieNazwisko from autor";
            

            
            DataSeting(polecenie_autor, "autor");
                

            int ile_autorow = ds.Tables["autor"].Rows.Count;

            for (int i = 0; i < ile_autorow; i++)
            {
                string a = ds.Tables["autor"].Rows[i][3].ToString();
                cmbAutor.Items.Add(a);
            }


        }

        //Dodawanie ksiazki
        private void Btn_dodaj_ksiazke_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //Dodawanie ksiazek
                string tytul = txt_tytul.Text;
                string polecenie = "select * from ksiazki";
                string nazwa_ksiazki = "ksiazki";

                DataSeting(polecenie, nazwa_ksiazki);

                DataRow dr = ds.Tables["ksiazki"].NewRow();
                
                dr["tytul"] = tytul;

                ds.Tables["ksiazki"].Rows.Add(dr);

                SqlCommandBuilder sqlbuild = new SqlCommandBuilder(sqlada);
                sqlada.Update(ds, "ksiazki");


                DataSeting(polecenie, nazwa_ksiazki);


                int nr_ostatniej_ksiazki = ds.Tables["ksiazki"].Rows.Count;
                id_ksiazki = ds.Tables["ksiazki"].Rows[nr_ostatniej_ksiazki - 1][0].ToString();



                //Poszukiwanie id autora wybranego z Comboboxa
                
                string polecenie_autor = "select *, (imie+' '+nazwisko) as imieNazwisko from autor";
                string nazwa_autor = "autor";

                DataSeting(polecenie_autor, nazwa_autor);

                if (tytul != " " && cmbAutor.SelectedIndex > -1)
                {

                    string autor = cmbAutor.SelectedItem.ToString();
                string id_autora = "";
                int ile_autorow = ds.Tables["autor"].Rows.Count;

                for (int i = 0; i < ile_autorow; i++)
                {
                    if (ds.Tables["autor"].Rows[i][3].ToString() == autor)
                    {
                        id_autora = ds.Tables["autor"].Rows[i][0].ToString();
                    }
                }

               
                    //Dodawnie idi-ków do tabeli autorzyKsiazki
                    string polcenie2 = "select * from autorzyKsiazki";
                    string nazwa_autorzyksiazki = "autorzyKsiazki";

                    DataSeting(polcenie2, nazwa_autorzyksiazki);

                    DataRow dr2 = ds.Tables["autorzyKsiazki"].NewRow();

                    dr2["id_aksiazki"] = id_ksiazki;
                    dr2["id_autor"] = id_autora;

                    ds.Tables["autorzyKsiazki"].Rows.Add(dr2);

                    sqlbuild = new SqlCommandBuilder(sqlada);
                    sqlada.Update(ds, "autorzyKsiazki");
                    MessageBox.Show("Dodano ksiażkę " + tytul + "");
                }
            }
            catch (FormatException )
            {
                MessageBox.Show("Wprowadzono błędne dane");
            }
            catch(SqlException f)
            {
                MessageBox.Show(f.Message);
            }
        }

        //Funkcja dataseting
        private void DataSeting(string polecenie, string nazwa)
        {
            string polcenie2 = polecenie;
            string nazwa_tabeli = nazwa;

            ds = new DataSet();

            sqlada = new SqlDataAdapter(polcenie2, conn);
            sqlada.Fill(ds, nazwa_tabeli);

        }


         //Powrót   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page2(frame1, conn);

        }
    }
}
