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
using Xceed.Wpf.Toolkit;

namespace Biblioteka_system.Main
{
    /// <summary>
    /// Logika interakcji dla klasy Color.xaml
    /// </summary>
    public partial class Color : Window
    {
        Frame frm;
        public Color()
        {
            InitializeComponent();
        }

        public Color(Frame frm)
        {
            InitializeComponent();
            this.frm = frm;



        }


        private void Btn_ok_Click(object sender, RoutedEventArgs e)
        {
           // int nr = cmb_color.SelectedIndex;

            //switch(nr)
            //{

            //    case 0:
            //        frm.Background = new SolidColorBrush(Colors.Green);
            //        break;

            //    case 1:
            //        frm.Background = new SolidColorBrush(Colors.Blue);
            //        break;

            //    case 2:
            //        frm.Background = new SolidColorBrush(Colors.Red);
            //        break;

            //}



            this.Close();
        }

        private void ColPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            var col= ColPicker.SelectedColor.Value;
            frm.Background = new SolidColorBrush(col);
           
            ColorPickers1.Background = new SolidColorBrush(col);
          
        }

        
    }
}
