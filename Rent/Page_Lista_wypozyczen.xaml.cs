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

namespace Biblioteka_system
{
    /// <summary>
    /// Logika interakcji dla klasy Page_Lista_wypozyczen.xaml
    /// </summary>
    public partial class Page_Lista_wypozyczen : Page
    {


        BibliotekaEntities db;

       
        Boolean wys = true;
       

      

        public Page_Lista_wypozyczen(BibliotekaEntities db)
        {
            InitializeComponent();

            this.db = db;

            
          


            ShowList(wys);


        }


        //Wyszukiwanie spośrod zamówień
        private void Txt_Szukaj_TextChanged(object sender, TextChangedEventArgs e)
        {
            string info = txt_Search.Text;
           
            if (wys == true)
            {
                //polecenie_szukania_zamowienia = "select * from wypozyczenia w join klienci k on k.idklient = w.id_klienta join autorzyksiazki ak on ak.id_ak = w.id_ak join ksiazki ks on ks.idksiazki = ak.id_aksiazki where id_wypozyczenia like '%" + dane + "%' or imie like '%" + dane + "%' or nazwisko like '" + dane + "' or(imie + ' ' + nazwisko) like '%" + dane + "%' or tytul like '%" + dane + "%' or data_zwrotu like '%" + dane + "%' ";

                var linqRent = from rent in db.Rent
                               join client in db.Clients on rent.IdClient equals client.IdClient
                               join book in db.Books on rent.IdBook equals book.IdBook
                               where rent.IdRent.ToString()==info || client.Firstname.Contains(info) ||
                               client.Surename.Contains(info) || book.Title.Contains(info) || rent.DateReturn.Day.ToString().Contains(info)   
                               orderby client.Surename
                               select new Order { id_rent = rent.IdRent, firstname = client.Firstname, surename = client.Surename, title = book.Title, dateReturn = rent.DateReturn ,idclient=client.IdClient };
                //select new { id_wypozyczenia = rent.id_wypozyczenia, imie = client.imie, nazwisko = client.nazwisko, tytul = book.tytul, data_zwrotu = rent.data_zwrotu };


                listViewRent1.ItemsSource = linqRent.ToList();
                lbl_much.Content = listViewRent1.Items.Count.ToString();



            }
            else
            {
                //  polecenie_szukania_zamowienia = "select * from wypozyczenia w join klienci k on k.idklient = w.id_klienta join autorzyksiazki ak on ak.id_ak = w.id_ak join ksiazki ks on ks.idksiazki = ak.id_aksiazki where w.data_zwrotu < '" + data+"' and (id_wypozyczenia like '%" + dane + "%' or imie like '%" + dane + "%' or nazwisko like '" + dane + "' or(imie + ' ' + nazwisko) like '%" + dane + "%' or tytul like '%" + dane + "%' or data_zwrotu like '%" + dane + "%' )";
                var linqRent = from rent in db.Rent
                               join client in db.Clients on rent.IdClient equals client.IdClient
                               join book in db.Books on rent.IdBook equals book.IdBook
                               where( rent.IdRent.ToString() == info || client.Firstname.Contains(info) ||
                               client.Surename.Contains(info) || book.Title.Contains(info) || rent.DateReturn.Day.ToString().Contains(info)) &
                               rent.DateReturn < DateTime.Now
                               orderby client.Surename
                               select new Order { id_rent = rent.IdRent, firstname = client.Firstname, surename = client.Surename, title = book.Title, dateReturn = rent.DateReturn, idclient = client.IdClient };





                listViewRent1.ItemsSource = linqRent.ToList();
                lbl_much.Content = listViewRent1.Items.Count.ToString();


            }

            
        }


        //Zamykanie wypożyczenia
        private void Btn_zamknij_wyp_Click(object sender, RoutedEventArgs e)
        {


            int indexwyp = listViewRent1.SelectedIndex;

            try
            {
                if (indexwyp > -1)
                {
                 

                    if (MessageBox.Show("Czy chcesz zamknąć wypożyczenie ? ", "Uwaga", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {

                        

                        Order order1 = new Order();

                        order1 = (Order)listViewRent1.SelectedItem;


                        Rent wypozyczenia1 = new Rent();

                        wypozyczenia1 = db.Rent.Find(order1.id_rent);

                        db.Rent.Remove(wypozyczenia1);
                        db.SaveChanges();

                        ShowList(wys);

                    }
                }
                else
                {
                    MessageBox.Show("Musisz wybrać wypożyczenie", "Uwaga");
                }
            }
            catch (SqlException f)
            {
                MessageBox.Show(f.Message);
            }


        }


        //Zamówienia przeterminowane
        private void Btn_over_Click(object sender, RoutedEventArgs e)
        {
            if (wys == true)
            {
                 wys = false;
                ShowList(wys);
               

                btn_over.Content = "Wyświetl wszystkie wyp ";
                lbl_info.Content = "Zamówienia przeterminowane";
            }
            else
            {
                wys = true;
               
                ShowList(wys);
              

                btn_over.Content = "Wypożyczenia przeterminowane";
                lbl_info.Content = "Wszystkie zamówienia";

            }
        }


        //funkcja show list
        private void ShowList(bool actual)
        {
            if (actual)
            {
                var linqRent = from rent in db.Rent
                               join client in db.Clients on rent.IdClient equals client.IdClient
                               join book in db.Books on rent.IdBook equals book.IdBook
                               select new Order { id_rent = rent.IdRent, firstname = client.Firstname, surename = client.Surename, title = book.Title, dateReturn = rent.DateReturn, idclient = client.IdClient };

                // select new  { id_wypozyczenia = rent.id_wypozyczenia, imie = client.imie, nazwisko = client.nazwisko, tytul = book.tytul, data_zwrotu = rent.data_zwrotu };


                listViewRent1.ItemsSource = linqRent.ToList();
                


            }else
            {


                //over term
                var linqRent = from rent in db.Rent
                               join client in db.Clients on rent.IdClient equals client.IdClient
                               join book in db.Books on rent.IdBook equals book.IdBook
                               where rent.DateReturn < DateTime.Now
                               select new Order { id_rent = rent.IdRent, firstname = client.Firstname, surename = client.Surename, title = book.Title, dateReturn = rent.DateReturn, idclient = client.IdClient };




                listViewRent1.ItemsSource = linqRent.ToList();
               
            }
            lbl_much.Content = listViewRent1.Items.Count.ToString();

        }


        


        //Longer time
        private void Btn_upadte_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewRent1.SelectedIndex;

            if (index > -1)
            {

                Order order1 = new Order();
                order1 = (Order)listViewRent1.SelectedItem;

                Rent wypozyczenia1 = db.Rent.Find(order1.id_rent);

                wypozyczenia1.DateReturn = wypozyczenia1.DateReturn.AddDays(30);

                db.Entry(wypozyczenia1).State = EntityState.Modified;
                db.SaveChanges();

                ShowList(wys);
            }


        }



      
        //Wyswietlanie szczegółów
        private void Btn_szczegoly_Click(object sender, RoutedEventArgs e)
        {
            int numer = listViewRent1.SelectedIndex;
            if (numer > -1)
            {


                Order order1 = new Order();
                order1 = (Order)listViewRent1.SelectedItem;

                Szczegoly okno = new Szczegoly(order1, db);
                  okno.Show();



            }
            else
            {
                MessageBox.Show("Musisz wybrać wypożyczenie");
            }
        }

       
    }
}
