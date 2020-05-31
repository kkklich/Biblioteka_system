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
    /// Logika interakcji dla klasy Page_dodawanie_autorow.xaml
    /// </summary>
    public partial class Page_dodawanie_autorow : Page
    {
        BibliotekaEntities db;
        Frame frame1;

        public Page_dodawanie_autorow()
        {
            InitializeComponent();
        }
        public Page_dodawanie_autorow(Frame frame,BibliotekaEntities db)
        {
            InitializeComponent();
           
            frame1 = frame;
            this.db = db;

        }

        private void Btn_dodaj_autora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imie = txt_Name.Text;
                string nazwisko = txt_Surename.Text;
                string uwaga = "Czy chcesz dodać autora " + imie + " " + nazwisko + " ?";

                if (imie != "" && nazwisko != "")
                {
                    if (MessageBox.Show(uwaga, "Uwaga", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                      

                        Author autor1 = new Author();
                        autor1.FirstName = txt_Name.Text;
                        autor1.Surename = txt_Surename.Text;

                        db.Author.Add(autor1);
                        db.SaveChanges();


                        frame1.Content = new Autorzy_Page(frame1,db);


                    }
                }

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            frame1.Content = new Autorzy_Page(frame1,db);

        }
    }
}
