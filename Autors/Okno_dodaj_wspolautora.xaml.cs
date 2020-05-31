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
        BibliotekaEntities db;
        BookAuthor bookAuthor1;
     
        Frame frame1;



        public Okno_dodaj_wspolautora()
        {
            InitializeComponent();
        }

        public Okno_dodaj_wspolautora(Frame frame1 ,BookAuthor bookAuthor1,BibliotekaEntities db)
        {
            InitializeComponent();

            this.db = db;
            this.bookAuthor1 = bookAuthor1;
            this.frame1 = frame1;

            cmb_CoAuthor.ItemsSource = db.Author.ToList();
            lbl_bookName.Content = bookAuthor1.Title;


        }


        //Przycisk dodawania wspolautora
        private void Btn_dodaj_autora_Click(object sender, RoutedEventArgs e)
        {

            

            if (cmb_CoAuthor.SelectedIndex>-1)
            {


                AuthorsBook authorsBook1 = new AuthorsBook();

                Author autor1 = (Author)cmb_CoAuthor.SelectedItem;

                authorsBook1.IdAuthor = autor1.IdAuthor;
                authorsBook1.IdBook = bookAuthor1.IdBook;
              

                db.AuthorsBook.Add(authorsBook1);
                db.SaveChanges();

                this.Close();

            }
        }


       

       
    }
}
