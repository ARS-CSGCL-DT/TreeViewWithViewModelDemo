using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TreeViewWithViewModelDemo
{
    /// <summary>
    /// Interaction logic for Model.xaml
    /// </summary>
    public partial class Model : Window
    {
        public Model()
        {
            InitializeComponent();
        }

        private void btn_Maize_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new DemoWindow();
            newWindow.Show();
        }
    }
}
