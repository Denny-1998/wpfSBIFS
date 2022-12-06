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
    /// Interaktionslogik für HomeView.xaml
    /// </summary>
    public partial class HomeView : AdminPanel
    {
        ServerConnectionAdapter sva;
        public HomeView(ServerConnectionAdapter sva)
        {
            this.sva = sva;
            InitializeComponent();
        }
        public void GetUserCount()
        {
            
        }
    }
}
