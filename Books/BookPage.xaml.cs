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
    /// Logika interakcji dla klasy Page2.xaml
    /// </summary>
    /// 
    public class BookAuthor
    {

        public int IdBook { get; set; }
        public int IdAuthorsBook { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string SureName { get; set; }
    }


    public partial class Page2 : Page
    {

       
        BibliotekaEntities db;

        Frame frame2;
        
       
        public Page2()
        {
            InitializeComponent();
        }

        public Page2(Frame frame2,BibliotekaEntities db)
        {
            InitializeComponent();
            this.frame2 = frame2;
            this.db = db;

            var linqsearch = from book in db.Books
                             join ak in db.AuthorsBook on book.IdBook equals ak.IdBook
                             join author in db.Author on ak.IdAuthor equals author.IdAuthor
                             select new BookAuthor  {IdBook = book.IdBook , Title = book.Title, Firstname = author.FirstName, SureName = author.Surename };



          

            listView_ksiazka.ItemsSource = linqsearch.ToList();
            lbl_ilosc.Content = listView_ksiazka.Items.Count;

        }

        //Przycisk dodawanie ksiazek
        private void Btn_dodaj_ksiazke_Click(object sender, RoutedEventArgs e)
        {
            frame2.Content = new Page_dodawanie_ksiazek(frame2,db);
        }

        //Przycisk edycji ksiazek
        private void Btn_edytuj_ksiazke_Click(object sender, RoutedEventArgs e)
        {
            int id_ksiazki = listView_ksiazka.SelectedIndex;
           
            BookAuthor Ba1 = (BookAuthor)listView_ksiazka.SelectedItem;

            if (id_ksiazki > -1)
            {
                
                frame2.Content = new Page_edycja_usun_ksiazke(Ba1,frame2,db);
            }
            else
            {
                MessageBox.Show("Muisz wybrać książkę","Uwaga");
            }
        }

        //Wyszukiwanie ksiazek
        private void Txt_szukaj_ksiazke_TextChanged(object sender, TextChangedEventArgs e)
        {
            string info = txt_szukaj_ksiazke.Text;

            
            var linqsearch = from book in db.Books
                           join ak in db.AuthorsBook on book.IdBook equals ak.IdBook
                           join author in db.Author on ak.IdAuthor equals author.IdAuthor
                           where book.Title.Contains(info) || 
                           author.FirstName.Contains(info) || author.Surename.Contains(info) ||
                           (author.FirstName+" "+author.Surename).Contains(info)
                            select new BookAuthor { IdBook = book.IdBook, Title = book.Title, Firstname = author.FirstName, SureName = author.Surename };
         
            //    select new { idksiazki=book.IdBook, tytul =book.Title, imie=author.FirstName, nazwisko=author.Surename };

            listView_ksiazka.ItemsSource = linqsearch.ToList();

            lbl_ilosc.Content = listView_ksiazka.Items.Count;
        }

        //Przycisk dodawanie wspolautora
        private void Btn_kolejny_autor_Click(object sender, RoutedEventArgs e)
        {
            int index_ksiazki = listView_ksiazka.SelectedIndex;
            if (index_ksiazki>-1)
            {

                BookAuthor Ba1 = (BookAuthor)listView_ksiazka.SelectedItem;

                Okno_dodaj_wspolautora okno = new Okno_dodaj_wspolautora( frame2,Ba1, db);
                okno.Show();
            }
            else
            {
                MessageBox.Show("Muisz wybrać książkę","Uwaga");
            }


        }

        
    }
}
