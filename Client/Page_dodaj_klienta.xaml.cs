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
using System.Text.RegularExpressions;
using Biblioteka_system.Client;

namespace Biblioteka_system.Client
{
    /// <summary>
    /// Logika interakcji dla klasy Page_dodaj_klienta.xaml
    /// </summary>
    public partial class Page_dodaj_klienta : Page
    {
        
        Frame frame1;
        BibliotekaEntities db;
        

        public Page_dodaj_klienta()
        {
            InitializeComponent();
        }

        public Page_dodaj_klienta(Frame frame1,BibliotekaEntities db)
        {
            InitializeComponent();
          
            this.frame1 = frame1;
            this.db = db;

        }


        //Przycisk dodawanie klienta
        private void Btn_dodaj_kli_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_name.Text != "" && txt_surename.Text != "" && txt_nrPhone.Text != "")
                {

                string name = txt_name.Text;
                string suremane = txt_surename.Text;
                string nrphone = txt_nrPhone.Text;
                string info = txt_info.Text;
                string uwaga = "Czy chcesz dodać uzytkownika " + name + " " + suremane+ " ?";

                
                    if (MessageBox.Show(uwaga, "Uwaga", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                      
                        Clients klienci1 = new Clients();

                        klienci1.Firstname = name;
                        klienci1.Surename = suremane;
                        klienci1.NrPhone = nrphone;
                        klienci1.Info = info;

                        db.Clients.Add(klienci1);
                        db.SaveChanges();
                        

                        MessageBox.Show("Dodano klienta");
                        frame1.Content = new ClientPage(frame1, db);
                    }
                }
                else
                {
                    MessageBox.Show("Nie wszystkie pola są wypełnione ");
                }
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
            }


            
        }

        //Powrót
        private void Button_Click(object sender, RoutedEventArgs e)
        {

               frame1.Content = new ClientPage(frame1,db);

        }

        //Sprawdzanie poprawności nr telefonu
        private void Txt_nr_tel_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");

            if (txt_nrPhone.Text.Length == 9 && regex.IsMatch(txt_nrPhone.Text))
            {
                btn_AddClient.IsEnabled = true;
            }
            else
            {
                btn_AddClient.IsEnabled = false;
            }   
        }

        private void Txt_uwagi_TextChanged(object sender, TextChangedEventArgs e)
        {

            String slowo = txt_info.Text;
            int iloscslow = slowo.Length;

            if (iloscslow > 100)
            {
                btn_AddClient.IsEnabled = false;
                label_words.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                btn_AddClient.IsEnabled = true;
                label_words.Foreground = new SolidColorBrush(Colors.Black);
            }

            String count = iloscslow.ToString() + "/100";
            label_words.Content = count;
        }
    }
}
