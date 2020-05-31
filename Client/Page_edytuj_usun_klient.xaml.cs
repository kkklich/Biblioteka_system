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
using Biblioteka_system.Client;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace Biblioteka_system.Client
{
    /// <summary>
    /// Logika interakcji dla klasy Page_edytuj_usun_klient.xaml
    /// </summary>
    public partial class Page_edytuj_usun_klient : Page
    {
        BibliotekaEntities db;
        Clients client1;
        ClientInfo clientInfo1;

       
        Frame frame1;
        int Words = 0;

        public Page_edytuj_usun_klient()
        {
            InitializeComponent();
        }

        public Page_edytuj_usun_klient(ClientInfo clientInfo1,Frame frame1, BibliotekaEntities db)
        {
            InitializeComponent();

            this.clientInfo1 = clientInfo1;
            this.frame1 = frame1;
            this.db = db;


            txt_name.Text = this.clientInfo1.Firstname.ToString();
            txt_surename.Text = this.clientInfo1.Surename.ToString();
            txt_nrPhone.Text = this.clientInfo1.NrPhone.ToString();
            txt_info.Text = this.clientInfo1.Info.ToString();

            client1 = db.Clients.Find(clientInfo1.IdClient);
        }


        ////Edytowanie klienta
        private void Btn_edytuj_klienta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                client1.Firstname = txt_name.Text;
                client1.Surename = txt_surename.Text;
                client1.NrPhone = txt_nrPhone.Text;
                client1.Info = txt_info.Text;

                db.Entry(client1).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("edytowano");
                frame1.Content = new ClientPage(frame1, db);
            } catch(SqlException f)
            {
                MessageBox.Show(f.Message);

            }catch(Exception f)
            {
                MessageBox.Show(f.Message);
            }



        }

        //Usuwanie klienta
        private void Btn_usun_klienta_Click(object sender, RoutedEventArgs e)
        {

            try
            {


                if (int.Parse(clientInfo1.quantity) > 0)
                {
                    MessageBox.Show("Użytkownika ma wypozyczoną książkę, nie można go usunąć");
                }
                else
                {
                    if (MessageBox.Show("Czy chcesz usuną klienta " + clientInfo1.Firstname + " ?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        db.Clients.Remove(client1);
                        db.SaveChanges();
                    }


                    MessageBox.Show("Usunięto");
                    frame1.Content = new ClientPage(frame1, db);
                }
            }catch(SqlException f)
            {
                MessageBox.Show(f.Message);
            }catch(Exception f)
            {
                MessageBox.Show(f.Message);
            }


         }

        //Powrót
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new ClientPage(frame1,db);
        }

        //Sprawdzanie ile jest znaków w tekscie Uwagi
        private void Txt_uwagi_TextChanged(object sender, TextChangedEventArgs e)
        {
            
               Words = txt_info.Text.Length;
            
            if (Words > 100)
            {
                btn_EditClient.IsEnabled = false;
                label_words.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                label_words.Foreground = new SolidColorBrush(Colors.Black);
                btn_EditClient.IsEnabled = true;
            }
           
            
            label_words.Content = Words.ToString() + "/100";
        }

        private void txt_nrPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");

            if (txt_nrPhone.Text.Length == 9 && regex.IsMatch(txt_nrPhone.Text))
            {
                btn_EditClient.IsEnabled = true;
                lblWorgNumber.Content = null;
            }
            else
            {
                btn_EditClient.IsEnabled = false;
                lblWorgNumber.Content = "Zły numer telefonu";
                lblWorgNumber.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}

