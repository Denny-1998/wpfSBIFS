using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using wpfSBIFS.ViewModel;

namespace wpfSBIFS.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        ILoginViewModel loginViewModel;
        HttpClient client;

        public LoginView(ILoginViewModel viewModel)
        {
            InitializeComponent();

            // Set viewmodel received from DI as binding context
            loginViewModel = viewModel;
            this.DataContext = viewModel;
        }
        

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            //get login data from the ui
            string userName = tbUserName.Text;
            string passWord = pbPassword.Password;


            //hard coded values for now
            string hostName = "localhost";
            int port = 8080;

            HttpClient client= new HttpClient();

            ServerConnectionAdapter sva = new ServerConnectionAdapter(hostName,port, client, lblLoginStatus);

            if (await sva.Login(userName, passWord))
            {
                this.Visibility = Visibility.Hidden;
            

                AdminPanel p = new AdminPanel();
                p.Show();
                
            }
            


        }
        
        public void Username_OnClick(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Opacity = 1;
            tb.Text = string.Empty;
            tb.GotFocus -= Username_OnClick;
        }
        public void Password_OnClick(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = (PasswordBox)sender;
            pb.Opacity = 1;
            pb.Password = string.Empty;
            pb.GotFocus -= Password_OnClick;
        }
    }
    
}
