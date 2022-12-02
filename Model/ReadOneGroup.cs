using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpfSBIFS.Tools;

namespace wpfSBIFS.Model
{
    internal class ReadOneGroup
    {
        HttpClient client;
        string _HostName;
        int _Port;
        public ReadOneGroup(string HostName, int Port, HttpClient client)
        {
            _HostName = HostName;
            _Port = Port;
            this.client = client;

        }
        public async Task<string> Login(string User, string Password, string jwt)
        {

            //error handling for if user or password is empty 
            if (Util.CheckUsernamePassword(User, Password)) MessageBox.Show("Please enter username & password!");

            //attaching user and password to login json 
            IJson loginJson = new LoginJson
            {
                Email = User,
                Password = Password,
            };

            //making the login request
            var response = await client.PostAsJsonAsync("https://localhost:8080/Api/Auth/Login", loginJson);

            //defining the cariable statuscode which was extracted from the request response
            var StatusCode = (Int32)response.StatusCode;

            //Checking the statuscode for all kinds of error statuscodes
            if (Util.CheckStatusCode(StatusCode) != "")
            {
                MessageBox.Show((Util.CheckStatusCode(StatusCode)));
                return "";
            }

            //parsing the response text 
            JObject json = JObject.Parse(response.Content.ToString());

            //getting the jwt login token from response text
            jwt = (string)json["jwt"];
            return jwt;


        }
    }
}
