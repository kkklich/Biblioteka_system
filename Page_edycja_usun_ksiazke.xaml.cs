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
        Frame frame1;
        SqlCommandBuilder sqlbuilder;
        string ksiazki = "ksiazki";
        string tytul;
        string idKS, idAutora;

        public Page_edycja_usun_ksiazke()
        {
            InitializeComponent();
        }

        public Page_edycja_usun_ksiazke(SqlConnection conn,int id_ksiazki,Frame frame1)
        {
            InitializeComponent();
            this.conn = conn;
            this.id_ksiazki = id_ksiazki;
            this.frame1 = frame1;
            
           ds = new DataSet();

            string polecenie2 = "select * from ksiazki";

            sqlada = new SqlDataAdapter(polecenie2, conn);
            sqlada.Fill(ds, ksiazki);

            tytul= ds.Tables["ksiazki"].Rows[id_ksiazki]["tytul"].ToString();
            idKS = ds.Tables["ksiazki"].Rows[id_ksiazki]["idksiazki"].ToString();
            txt_tytul.Text = ds.Tables["ksiazki"].Rows[id_ksiazki]["tytul"].ToString();
             txt_tytul.IsEnabled = false;
            string id = ds.Tables[ksiazki].Rows[id_ksiazki][0].ToString();
           
            

            string polecenie_autor = "select *, (imie + ' ' + nazwisko) as imieNazwisko from ksiazki k join autorzyKsiazki ak on ak.id_aksiazki = k.idksiazki join autor a on a.id_autor = ak.id_autor where k.tytul like '"+tytul+"'";
            DataSeting(polecenie_autor, "autor");

            
            int ile_autorow = ds.Tables["autor"].Rows.Count;
            String nazwiskoA = "";

            for (int i = 0; i < ile_autorow; i++)
            {   
                if(i==0)
                nazwiskoA = ds.Tables["autor"].Rows[0]["imie"].ToString()+" "+ ds.Tables["autor"].Rows[i]["nazwisko"].ToString();

                string a = ds.Tables["autor"].Rows[i]["imie"].ToString() + " " + ds.Tables["autor"].Rows[i]["nazwisko"].ToString();
                cmb_Autor.Items.Add(a);
            }

            
            
            cmb_Autor.SelectedItem = nazwiskoA;

            
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page2(frame1, conn);
        }


        //funkcja dataseting
        private void DataSeting(string polecenie, string nazwa)
        {
            string polcenie2 = polecenie;
            string nazwa_tabeli = nazwa;

            ds = new DataSet();

            sqlada = new SqlDataAdapter(polcenie2, conn);
            sqlada.Fill(ds, nazwa_tabeli);

        }

        private void Btn_usun_ksiazke_Click(object sender, RoutedEventArgs e)
        {

            try {

                //usuwanie z tabeli autorzyksiazki
                string autorzyksiazki = "autorzyksiazki";

                string pol = "select * from autorzyksiazki";

                ds = new DataSet();
                sqlada = new SqlDataAdapter(pol, conn);
                sqlada.Fill(ds, autorzyksiazki);


                ds.Tables[autorzyksiazki].Rows[id_ksiazki].Delete();
                sqlbuilder = new SqlCommandBuilder(sqlada);
               sqlada.Update(ds, autorzyksiazki);
                
                }
            catch (SqlException )
            {
                MessageBox.Show("Książka jest wypożyczona i nie można jej usunąć! ");
            }

            try {
                //usuwanie z tabeli ksiazki

                string ksiazki = "ksiazki";
                string polksiazki = "select * from ksiazki";
                ds = new DataSet();
                sqlada = new SqlDataAdapter(polksiazki, conn);
                sqlada.Fill(ds, ksiazki);


                ds.Tables[ksiazki].Rows[id_ksiazki].Delete();
                sqlbuilder = new SqlCommandBuilder(sqlada);
                sqlada.Update(ds, ksiazki);
                               
            }
            catch (SqlException )
            {
                //MessageBox.Show(f.Message);
            }

        }

        //Usuwanie wspolautora
        private void Btn_usun_autora_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (cmb_Autor.Items.Count > 1)
                {
                    string polecenie_autor = "select *, (imie + ' ' + nazwisko) as imieNazwisko from ksiazki k join autorzyKsiazki ak on ak.id_aksiazki = k.idksiazki join autor a on a.id_autor = ak.id_autor where k.tytul like '" + tytul + "'";
                    DataSeting(polecenie_autor, "autor");

                    idAutora = ds.Tables["autor"].Rows[cmb_Autor.SelectedIndex]["id_autor"].ToString();
                    string Imie = ds.Tables["autor"].Rows[cmb_Autor.SelectedIndex]["imie"].ToString();
                    string nazwisko = ds.Tables["autor"].Rows[cmb_Autor.SelectedIndex]["nazwisko"].ToString();


                    string polecenieusuwania = "select * from autorzyksiazki where id_autor = " + idAutora + " and id_aksiazki = " + idKS + "";
                    DataSeting(polecenieusuwania, "autorzyksiazki");

                    int ilosc = ds.Tables["autorzyksiazki"].Rows.Count;

                    
                    ds.Tables["autorzyksiazki"].Rows[0].Delete();
                    sqlbuilder = new SqlCommandBuilder(sqlada);
                    sqlada.Update(ds, "autorzyksiazki");

                    string tekst = "Usunięto współautora " + Imie + " " + nazwisko;
                    MessageBox.Show(tekst);
                }
            }
            catch(SqlException f)
            {
                MessageBox.Show(f.Message);
            }

        }
    }
}
