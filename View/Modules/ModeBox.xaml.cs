using System;
using System.ComponentModel;
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

namespace RealReceiptApp.View.Modules
{
    /// <summary>
    /// Interaction logic for ModeBox.xaml
    /// </summary>
    public partial class ModeBox : UserControl, INotifyPropertyChanged
    {
        public ModeBox()
        {
            DataContext = this;
            color = DefaultColor;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private string radioButtonname;
        public string RadioButtonGroup
        {
            get { return radioButtonname; }
            set
            {
                radioButtonname = value;
                OnPropertyChanged("RadioButtonGroup");
            }
        }

        private string labeltext;
        public string TextContent
        {
            get { return labeltext; }
            set
            {
                labeltext = value;
                OnPropertyChanged("TextContent");
            }
        }

        private string clr;

        public string color
        {
            get { return clr; }
            set
            {
                clr = value;
                OnPropertyChanged("color");
            }
        }


        private string baseClr = "#fff";
        public string DefaultColor
        {
            get { return baseClr; }
            set
            {
                baseClr = value;
                OnPropertyChanged("DefaultColor");
            }
        }

        private string mOverClr = "#ccc";
        public string MouseOverColor
        {
            get { return mOverClr; }
            set
            {
                mOverClr = value;
                OnPropertyChanged("MouseOverColor");
            }
        }

        private string slctdClr = "#888";
        public string SelectedColor
        {
            get { return slctdClr; }
            set
            {
                slctdClr = value;
                OnPropertyChanged("SelectedColor");
            }
        }

        private void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void base_MouseEnter(object sender, MouseEventArgs e)
        {

            color = MouseOverColor;
        }

        private void base_MouseLeave(object sender, MouseEventArgs e)
        {
            color = DefaultColor;
        }
    }
}
