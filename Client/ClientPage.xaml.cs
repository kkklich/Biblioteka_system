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
using System.Data.Entity;

namespace Biblioteka_system.Client
{
    /// <summary>
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    /// 

    public class ClientInfo
    {
        public int IdClient { get; set; }
        public string Firstname { get; set; }
        public string Surename { get; set; }
        public string NrPhone { get; set; }
        public string Info { get; set; }
        public string quantity { get; set; }
    }


    public partial class ClientPage : Page
    {
        Frame frame1;
        BibliotekaEntities db;

        public ClientPage()
        {
            InitializeComponent();
            
        }

      

        public ClientPage(Frame frame1, BibliotekaEntities db)
        {
            InitializeComponent();
            this.frame1 = frame1;
            this.db = db;


            var linqClient = from x in db.Clients
                             join y in db.clientQuantity on x.IdClient equals y.IdClient
                             select new ClientInfo { Firstname = x.Firstname, Surename = x.Surename, IdClient = x.IdClient, NrPhone = x.NrPhone, Info = x.Info, quantity =  y.quantity.ToString() };


            listView.ItemsSource = linqClient.ToList();
            lbl_ilosc.Content = listView.Items.Count;
            

        }

            //Dodawanie klientow
        private void Btn_dodaj_klienta_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page_dodaj_klienta(frame1,db);
        }

        //Edycja klientow
        private void Btn_edytuj_klienta_Click(object sender, RoutedEventArgs e)
        {


            if (listView.SelectedIndex > -1)
            {

                ClientInfo clientInfo1 = (ClientInfo)listView.SelectedItem;
                frame1.Content = new Page_edytuj_usun_klient(clientInfo1, frame1, db);

            }
            else
            {
                MessageBox.Show("Wybierz klienta");
            }


          
        }

        //Wyszukiwanie klientow
        private void Txt_szukaj_TextChanged(object sender, TextChangedEventArgs e)
        {
            string info = txt_search.Text;


            var linqLooking = from item in db.Clients
                              join y in db.clientQuantity on item.IdClient equals y.IdClient
                              where (item.Firstname + " " + item.Surename).Contains(info) ||
                              item.Firstname.Contains(info) || item.Surename.Contains(info) ||
                              item.NrPhone.Contains(info) ||
                              item.Info.Contains(info)
                              
                              select new ClientInfo { Firstname = item.Firstname, Surename = item.Surename, IdClient = item.IdClient, NrPhone = item.NrPhone, Info = item.Info, quantity = y.quantity.ToString() };


            listView.ItemsSource = linqLooking.ToList();

            lbl_ilosc.Content = listView.Items.Count;
        }
    }
}
