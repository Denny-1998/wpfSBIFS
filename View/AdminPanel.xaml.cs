using MaterialDesignThemes.Wpf;
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
using wpfSBIFS.Core;
using wpfSBIFS.Model;

namespace wpfSBIFS.View
{
    /// <summary>
    /// Interaktionslogik für AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        ServerConnectionAdapter sva;
        public AdminPanel(ServerConnectionAdapter serverConnectionAdapter)
        {
            this.sva = serverConnectionAdapter;
            InitializeComponent();
           

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        

        
    }
}
