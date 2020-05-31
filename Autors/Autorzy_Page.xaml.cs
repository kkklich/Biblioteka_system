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
    /// Logika interakcji dla klasy Autorzy_Page.xaml
    /// </summary>
    public partial class Autorzy_Page : Page
    {
        BibliotekaEntities db;
        Frame frame3;
        
       
        string nazwa_tabeli;
       

        public Autorzy_Page()
        {
            InitializeComponent();
        }


        public Autorzy_Page(Frame frame3,BibliotekaEntities db)
        {
            InitializeComponent();
            this.frame3 = frame3;
            this.db = db;
           
          
            listView_authors.ItemsSource = db.Author.ToList();
            lbl_number.Content = listView_authors.Items.Count;
        }

        //Przycisk dodawanie autora
        private void Btn_dodaj_autora_Click(object sender, RoutedEventArgs e)
        {
            frame3.Content = new Page_dodawanie_autorow(frame3,db);
        }

        //Przycisk edycji autora
        private void Btn_edytuj_autora_Click(object sender, RoutedEventArgs e)
        {
            int id_autora = listView_authors.SelectedIndex;
            if (id_autora > -1)
            {
                Author autor1 = (Author)listView_authors.SelectedItem;

                frame3.Content = new Page_edycja_usuwanie_autorow(autor1,frame3,db);
            }
            else
            {
                MessageBox.Show("Wybierz autora");
            }
        }

        //Wyszukiwanie autorów
        private void Txt_szukaj_autorow_TextChanged(object sender, TextChangedEventArgs e)
        {
            string info = txt_search.Text;
           
            var linqLook = from item in db.Author
                           where item.IdAuthor.ToString() == info ||
                           item.FirstName.Contains(info) ||
                           item.Surename.Contains(info) ||
                           (item.FirstName + " " + item.Surename).Contains(info)
                           select item;

            listView_authors.ItemsSource = linqLook.ToList();
            lbl_number.Content = listView_authors.Items.Count;
        }

        

    }
}
