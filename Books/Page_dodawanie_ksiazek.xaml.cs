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
        BibliotekaEntities db;
        Frame frame1;

     

        public Page_dodawanie_ksiazek()
        {
            InitializeComponent();
        }


        public Page_dodawanie_ksiazek(Frame frame1,BibliotekaEntities db)
        {
            InitializeComponent();
           
            this.frame1 = frame1;
            this.db = db;

            cmbAutor.ItemsSource = db.Author.ToList();
           

        }

        //Dodawanie ksiazki
        private void Btn_dodaj_ksiazke_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //Dodawanie ksiazek
                string title = txt_title.Text;

                Books books1 = new Books();
                books1.Title= title;

                db.Books.Add(books1);
                db.SaveChanges();



                Author autor2 = (Author)cmbAutor.SelectedItem;
                MessageBox.Show(autor2.IdAuthor.ToString());



                AuthorsBook authorsBook1 = new AuthorsBook();

                authorsBook1.IdAuthor = autor2.IdAuthor;
                authorsBook1.IdBook = books1.IdBook;

                db.AuthorsBook.Add(authorsBook1);
                db.SaveChanges();


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

       


         //Powrót   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page2(frame1,db);

        }
    }
}
