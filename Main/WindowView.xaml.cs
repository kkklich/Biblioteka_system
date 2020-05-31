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

namespace Biblioteka_system.Main
{
    /// <summary>
    /// Interaction logic for WindowView.xaml
    /// </summary>
    public partial class WindowView : Window
    {

        BibliotekaEntities db1 = new BibliotekaEntities();

       

        public WindowView()
        {
            InitializeComponent();

          //  db1.clientQuantity;

           
            

            listViewView1.ItemsSource = db1.clientQuantity.ToList();

               

          

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(e.GetPosition(this).ToString());
            MessageBox.Show(e.MouseDevice.ToString());
        }
    }
}
