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
using System.Data;
using System.Data.SqlClient;

namespace Biblioteka_system
{
    /// <summary>
    /// Logika interakcji dla klasy Okno_dodaj_wspolautora.xaml
    /// </summary>
    public partial class Okno_dodaj_wspolautora : Window
    {
        
        SqlConnection conn;
        string nazwa_ksiazki = "";
        DataSet ds;
        SqlDataAdapter sqlada;
        string id_ksiazki;
        Frame frame1;



        public Okno_dodaj_wspolautora()
        {
            InitializeComponent();
        }

        public Okno_dodaj_wspolautora(SqlConnection conn,Frame frame1 ,string nazwa_ksiazki, string id_ksiazki)
        {
            InitializeComponent();
            this.conn = conn;
            this.nazwa_ksiazki = nazwa_ksiazki;
            this.id_ksiazki = id_ksiazki;
            this.frame1 = frame1;
          
            string polecenie_autor = "select *, (imie+' '+nazwisko) as imieNazwisko from autor";
            polecenie_autor = "select * from autor where not exists(select * from autorzyksiazki where autorzyksiazki.id_autor = autor.id_autor and  id_aksiazki = " + id_ksiazki + ")";
           DataSeting(polecenie_autor, "autor");


            int ile_autorow = ds.Tables["autor"].Rows.Count;

            for (int i = 0; i < ile_autorow; i++)
            {
                string a = ds.Tables["autor"].Rows[i]["imie"].ToString() + " " + ds.Tables["autor"].Rows[i]["nazwisko"].ToString();
                cmb_wpspolautor.Items.Add(a);
            }

            string tekst="Dodawnie współautora do książki pt. "+nazwa_ksiazki+"";
            lbl_nazwa_ksiazki.Content = tekst;
        }


        //Przycisk dodawania wspolautora
        private void Btn_dodaj_autora_Click(object sender, RoutedEventArgs e)
        {

            //Ustalenie id_autora

            if (cmb_wpspolautor.SelectedIndex>-1)
            {
                string autor = cmb_wpspolautor.SelectedItem.ToString();
                string polecenie_autor = "select *, (imie+' '+nazwisko) as imieNazwisko  from autor  where (imie + ' ' + nazwisko)  like '"+autor+"'";
                string nazwa_autor = "autor";

                DataSeting(polecenie_autor, nazwa_autor);

                
                string id_autora =ds.Tables["autor"].Rows[0][0].ToString();
                


                //Dodawnie idi-ków do tabeli autorzyKsiazki
                string polcenie2 = "select * from autorzyKsiazki";
                string nazwa_autorzyksiazki = "autorzyKsiazki";

                DataSeting(polcenie2, nazwa_autorzyksiazki);

                DataRow dr2 = ds.Tables["autorzyKsiazki"].NewRow();

                dr2["id_aksiazki"] = id_ksiazki;
                dr2["id_autor"] = id_autora;

                ds.Tables["autorzyKsiazki"].Rows.Add(dr2);

                SqlCommandBuilder sqlbuild = new SqlCommandBuilder(sqlada);
                sqlada.Update(ds, "autorzyKsiazki");

                frame1.Content = new Page2(frame1, conn);

                this.Close();
            }
        }


        private void DataSeting(string polecenie, string nazwa)
        {
            string polcenie2 = polecenie;
            string nazwa_tabeli = nazwa;

            ds = new DataSet();

            sqlada = new SqlDataAdapter(polcenie2, conn);
            sqlada.Fill(ds, nazwa_tabeli);

        }

       
    }
}
