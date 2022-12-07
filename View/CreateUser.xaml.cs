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
using wpfSBIFS.Model;

namespace wpfSBIFS.View
{
    /// <summary>
    /// Interaktionslogik für CreateUser.xaml
    /// </summary>
    public partial class CreateUser : UserControl
    {
        ServerConnectionAdapter serverConnectionAdapter;
        public CreateUser(ServerConnectionAdapter serverConnectionAdapter)
        {
 
            this.serverConnectionAdapter = serverConnectionAdapter;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //get login data from the ui
            string userName = tbUserName.Text;
            string passWord = pbPassword.Text;

            //hard coded values for now
            string hostName = "localhost";
            int port = 8080;

            

        }
    }
}
