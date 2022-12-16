using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace wpfSBIFS.MVVM.ViewModel
{
    
    class ManageGroupsViewModel : ViewModelBase
    {
        public Dictionary<string, object> Data { get; set; }
        public ManageGroupsViewModel()
        {
           

            // First, deserialize the JSON data
            string json = "{'name':'John Doe','age':35}";

            // Use a JSON parsing library to deserialize the data
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            
            // Store the deserialized data in the property
            Data = data;
        }
    }
}
