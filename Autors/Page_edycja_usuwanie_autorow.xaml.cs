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
    /// Logika interakcji dla klasy Page_edycja_usuwanie_autorow.xaml
    /// </summary>
    public partial class Page_edycja_usuwanie_autorow : Page
    {

        BibliotekaEntities db;
        Author author1;

       
        Frame frame1;

        public Page_edycja_usuwanie_autorow()
        {
            InitializeComponent();
        }

        public Page_edycja_usuwanie_autorow(Author author1,Frame frame1,BibliotekaEntities db)
        {
            InitializeComponent();

            this.author1 = author1;
            this.frame1 = frame1;
            this.db = db;

            txt_name.Text = author1.FirstName;
            txt_surename.Text = author1.Surename;

        }

        //Edytowanie autora
        private void Btn_edytuj_autora_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                author1.FirstName  = txt_name.Text;
                author1.Surename = txt_surename.Text;

                db.Entry(author1).State = EntityState.Modified;
                db.SaveChanges();
                frame1.Content = new Autorzy_Page(frame1, db);

            }
            catch(SqlException f)
            {
                MessageBox.Show(f.Message);
            }
            catch(FormatException f)
            {
                MessageBox.Show(f.Message);
            }

        }

        //Usuwanie autora
        private void Btn_usun_autora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Czy chcesz usunąć autora " + txt_name.Text + " ?", "Uwaga!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                   

                    db.Author.Remove(author1);
                    db.SaveChanges();

                    MessageBox.Show("Usunięto autora");
                    frame1.Content = new Autorzy_Page(frame1, db);
                }
            }
            catch(SqlException )
            {
                MessageBox.Show("Nie można usunąć autora, prawdopodobnie jej/jego książki są w bazie danych ");
            }
        }

        //Powrót
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Autorzy_Page(frame1,db);
        }
    }
}
