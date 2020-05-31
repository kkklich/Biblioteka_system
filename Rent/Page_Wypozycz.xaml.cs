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
    /// Logika interakcji dla klasy Page_Wypozycz.xaml
    /// </summary>
    /// 


    public class Order
    {
        public int idclient { get; set; }
        public int id_rent { get; set; }
        public string firstname { get; set; }
        public string surename { get; set; }
        public int idbook { get; set; }
        public string title { get; set; }
        public DateTime dateReturn { get; set; }

    }

    public partial class Page_Wypozycz : Page
    {


        BibliotekaEntities db;
        List<Order> order2 = new List<Order>();

        

        public Page_Wypozycz(BibliotekaEntities db)
        {

            

            InitializeComponent();
            this.db = db;


            Listview_Client.ItemsSource = db.Clients.ToList();

            Listview_Book.ItemsSource = db.Books.ToList();

     
        }

        //Wyszukiwanie klientów
        private void Txt_szukaj_klientow_TextChanged(object sender, TextChangedEventArgs e)
        {
            string info = txt_serach.Text;



            var linqClient = from x in db.Clients
                             where x.IdClient.ToString() == info ||
                             x.Firstname.Contains(info) || x.Surename.Contains(info) ||
                             (x.Firstname + " " + x.Surename).Contains(info) || x.NrPhone.Contains(info)
                             select x;

            Listview_Client.ItemsSource = linqClient.ToList();

        }


        //Wyszukiwanie ksiazek
        private void Txt_szukaj_ksiazki_TextChanged(object sender, TextChangedEventArgs e)
        {
            string info = txt_serachBook.Text;

            var linqBook = from x in db.Books
                           where x.IdBook.ToString() == info ||
                              x.Title.Contains(info)
                           select x;

            Listview_Book.ItemsSource = linqBook.ToList();

        }


        //Przycisk Zamów
        private void Btn_zamów_Click(object sender, RoutedEventArgs e)
        {
                int index_klienta = Listview_Client .SelectedIndex;
                int index_ksiazki = Listview_Book.SelectedIndex;

            try { 
                if (index_klienta > -1 & index_ksiazki > -1)
                {

                    Order order1 = new Order();
                    

                    Clients klient1 = (Clients)Listview_Client.SelectedItem;

                    Books ksiazka1 = (Books)Listview_Book.SelectedItem;


                    order1.idclient = klient1.IdClient;
                    order1.firstname = klient1.Firstname;
                    order1.surename = klient1.Surename;
                    order1.idbook = ksiazka1.IdBook;
                    order1.title = ksiazka1.Title;

                    order2.Add(order1);

                    Listview_rent.ItemsSource = order2.ToList();

                    
                }
            }
            catch(SqlException f )
            {
                MessageBox.Show(f.Message);
            }
            catch (FormatException f)
            {
                MessageBox.Show(f.Message);
            }

            lbl_many.Content = Listview_rent.Items.Count;
        }





        //Dodawanie wypozyczen do tabeli wypozyczenia czyli do bazy danych
        private void Btn_Wypozycz_Film_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                int nrOfOrders = Listview_rent.Items.Count;
                DateTime dateNow = DateTime.Now;
                DateTime dateNext = dateNow.AddDays(30);

                if (nrOfOrders > 0)
                {
                     Rent rent1 = new Rent();

                    foreach(var x in order2)
                    {
                        

                        rent1.IdClient = x.idclient;
                        rent1.IdBook = x.idbook;
                        rent1.DateStart = dateNow;
                        rent1.DateReturn = dateNext;

                    //MessageBox.Show(rent1.id_klienta + "  "+rent1.id_ksiazki);

                        db.Rent.Add(rent1);
                        db.SaveChanges();
                    }


                   
                    MessageBox.Show("Złożono zamówienie");
                    Listview_rent.ItemsSource = null;

                    order2.Clear();
                   // Listview_rent.Items.Clear();
                }else
                {
                    MessageBox.Show("Złóż zamówienia");
                }
               
                


            }
            catch(SqlException f)
            {
                MessageBox.Show(f.Message);

            }
            
        }


        //W label bedzie wyswietla imie aktualnego klienta
        private void Listview_Klienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                int indexkl=Listview_Client.SelectedIndex;



            if (indexkl > -1)
            {

                Clients klienci1 = (Clients)Listview_Client.SelectedItem;

                lblclient.Content = klienci1.Firstname.ToString();
            }
        }
    }
}
