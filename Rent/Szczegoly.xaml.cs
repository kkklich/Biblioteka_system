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
using System.Data.SqlClient;
using System.Data;

namespace Biblioteka_system
{
    /// <summary>
    /// Logika interakcji dla klasy Szczegoly.xaml
    /// </summary>
    public partial class Szczegoly : Window
    {

        Order order1;
        BibliotekaEntities db;


        int numer, ile = 0;
       
        public Szczegoly()
        {
            InitializeComponent();
        }

        public Szczegoly(Order order,BibliotekaEntities db)
        {
            InitializeComponent();

            this.order1 = order;
            this.db = db;

          //  wyswietl = new Klasa_glowna();

            showWyp();
        }

     

        //Zamykanie okno szczegoly
        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Funkcja wyswitlajaca dane szczegolowe w polach tekstowych
        void showWyp()
        {


            Clients clients1 = new Clients();
                clients1= db.Clients.Find(order1.idclient);

           Rent wypozyczenia1 = new Rent();
                wypozyczenia1= db.Rent.Find(order1.id_rent);
          


            txt_ID.Text = order1.id_rent.ToString();
            txt_name.Text = order1.firstname;
            txt_surename.Text = order1.surename;
            txt_Nrtel.Text = clients1.NrPhone;
            txt_Datastart.Text = wypozyczenia1.DateStart.ToString();
            txt_DataReturn.Text = wypozyczenia1.DateReturn.ToString();
            txt_title.Text = order1.title;

          

        }


    }
}
