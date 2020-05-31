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
using System.Data.SqlClient;
using System.Data;


namespace Biblioteka_system.Main
{
    /// <summary>
    /// Logika interakcji dla klasy Wyloguj.xaml
    /// </summary>
    public partial class Wyloguj : Page
    {
        Menu menu1;
       
        DataSet ds;
        Frame frm1;
        BibliotekaEntities db;

        public Wyloguj()
        {
            InitializeComponent();
        }

        public Wyloguj(Menu menu1,Frame frm)
        {
            InitializeComponent();
            this.menu1 = menu1;
            
            this.frm1 = frm;
            menu1.IsEnabled = false;
        }

        private void Btn_loguj_Click(object sender, RoutedEventArgs e)
        {
           
            int count = ds.Tables["pracownicy"].Rows.Count;
            Boolean ifemployee = false;

            for (int i = 0; i < count; i++)
            {
                String imie = ds.Tables["pracownicy"].Rows[i]["imie"].ToString();
                String nazwisko = ds.Tables["pracownicy"].Rows[i]["nazwisko"].ToString();
                if (txt_Name.Text == imie && txt_Surename.Text == nazwisko)
                {
                    frm1.Content = new Main_Page(frm1,db);
                    menu1.IsEnabled = true;
                    ifemployee = true;
                    break;
                }
                else
                {
                    ifemployee = false;
                }

            }

            if(ifemployee==false)
            {
                MessageBox.Show("Nie ma takiego pracownika");
            }
        }
    }
}
