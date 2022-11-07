using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Unity;
using wpfSBIFS.ViewModel;

namespace wpfSBIFS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // UnityContainer - DI for ViewModel first
        public static IUnityContainer container = new UnityContainer();

        // Reference to main windows content control
        public ContentControl ccRef { get; set; } = null;

        public App()
        {
            container.RegisterType<ILoginViewModel, LoginViewModel>();
        }

        // Method to change view
        public void ChangeUserControl(UserControl view)
        {
            this.ccRef.Content = view;
        }
    }
}
