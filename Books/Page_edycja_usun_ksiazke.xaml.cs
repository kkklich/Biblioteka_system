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
using System.Dynamic;
using System.Data.Entity;

namespace Biblioteka_system
{
    /// <summary>
    /// Logika interakcji dla klasy Page_edycja_usun_ksiazke.xaml
    /// </summary>
    public partial class Page_edycja_usun_ksiazke : Page
    {
        BibliotekaEntities db;
        Books books1;
        BookAuthor ba1;
        AuthorsBook authorsBook1;
        List<AuthorsBook> listaAK = new List<AuthorsBook>();


        Frame frame1;
       
        public Page_edycja_usun_ksiazke()
        {
            InitializeComponent();
        }

        public Page_edycja_usun_ksiazke(BookAuthor ba1,Frame frame1, BibliotekaEntities db)
        {
            InitializeComponent();

            this.ba1 = ba1;
            this.frame1 = frame1;
            this.db = db;

            books1 = db.Books.Find(ba1.IdBook);
            
            txt_title.Text = ba1.Title.ToString();

            var linqAuthor = from x in db.AuthorsBook
                             join y in db.Author on x.IdAuthor equals y.IdAuthor
                             where x.IdBook == ba1.IdBook
                             select new BookAuthor { Firstname = y.FirstName, SureName = y.Surename, IdAuthorsBook=x.IdAK };

            

            cmb_Author.ItemsSource = linqAuthor.ToList();
           

        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Page2(frame1,db);
        }



        private void Btn_usun_ksiazke_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Czy chcesz usuną książkę " + books1.Title+ " ?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {


                    var linqdeleteBook = from x in db.AuthorsBook
                                         where x.IdBook == books1.IdBook
                                         select x;

                    foreach(var x in linqdeleteBook)
                    {

                        AuthorsBook authorsBook1 = new AuthorsBook();
                        authorsBook1 = db.AuthorsBook.Find(x.IdAK);

                        db.AuthorsBook.Remove(authorsBook1);
                     

                    }

                    db.Books.Remove(books1);
                    db.SaveChanges();
                }


                MessageBox.Show("Usunięto");
                frame1.Content = new Page2(frame1, db);
            }
            catch (SqlException f)
            {
                MessageBox.Show(f.Message);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }




        }


        //Edit Title
        private void btn_EditTitle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                books1.Title = txt_title.Text;


                db.Entry(books1).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Zedytowano");
            }catch(SqlException f)
            {
                MessageBox.Show(f.Message);
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        //Usuwanie wspolautora
        private void Btn_usun_autora_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (cmb_Author.Items.Count <= 1)
                {
                    MessageBox.Show("To jest jedyny autor, możesz usunąć książkę");
                }
                else
                {

                    BookAuthor book = new BookAuthor();

                    book = (BookAuthor)cmb_Author.SelectedItem;

                    authorsBook1 = new AuthorsBook();
                    authorsBook1 = db.AuthorsBook.Find(book.IdAuthorsBook);

                    db.AuthorsBook.Remove(authorsBook1);
                    db.SaveChanges();


                    MessageBox.Show(book.IdAuthorsBook.ToString() + "   Usunięto");
                }

            }
            catch(SqlException f)
            {
                MessageBox.Show(f.Message);
            }

        }
    }
}
