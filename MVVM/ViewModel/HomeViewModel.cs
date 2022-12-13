using System.Threading.Tasks;
using System.Windows.Input;
using wpfSBIFS.Commands;
using wpfSBIFS.MVVM.Model;

namespace wpfSBIFS.MVVM.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public readonly ServerConnectionAdapter _sva;
        public ICommand HomeCommand { get; set; }
        public string HomeText { get; set; }
        public HomeViewModel(ServerConnectionAdapter sva)
        {
            _sva = sva;
            HomeCommand = new HomeCommand( _sva);
            GetUserCountAsync().ContinueWith(t => HomeText = t.Result);
        }

        // Define the GetUserCountAsync method
        private async Task<string> GetUserCountAsync()
        {
            int userCount = await _sva.GetUserCount();
            return userCount.ToString();
        }


    }
}
