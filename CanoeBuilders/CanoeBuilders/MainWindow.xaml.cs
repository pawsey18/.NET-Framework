using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace CanoeBuilders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillTypes();
        }

        private void FillTypes()
        {
            Dictionary<string, int> canoeTypes = new Dictionary<string, int>(){
                { "Aluminum", 1},
                { "Fiberglass", 2},
                { "Cedar-Strip", 3},
            };

            cboType.ItemsSource = canoeTypes;
            cboType.DisplayMemberPath = "Key";
            cboType.SelectedValuePath = "Value";

            cboType.SelectedIndex = 0;
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(cboType.SelectedValue.ToString());

        }
    }
}
