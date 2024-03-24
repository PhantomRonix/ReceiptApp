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

namespace ReceiptApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///  
    public partial class MainWindow : Window
    {
        private TextBox[] textboxes = new TextBox[3];

        public MainWindow()
        {
            InitializeComponent();
            textboxes[0] = NewItemNameBox;
            textboxes[1] = NewItemBrandNameBox;
            textboxes[2] = NewItemVolumeBox;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ClearNewDataButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBox box in textboxes)
            {
                box.Clear();
            }
            AddProductLogLabel.Content = "Fields cleared...";
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
