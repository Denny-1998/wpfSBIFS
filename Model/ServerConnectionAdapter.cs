using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using wpfSBIFS.Tools;
using System.Reflection.Emit;
using System.Windows.Controls;
using Label = System.Windows.Controls.Label;

namespace wpfSBIFS.Model { 

    public class ServerConnectionAdapter
    {
    
        
        HttpClient client;
        Label label;
        string _HostName;
        int _Port;
        string jwt;

      
        public ServerConnectionAdapter(string HostName, int Port, HttpClient client,Label label)
        {
            _HostName = HostName;
            _Port = Port;
            this.client = client;
            this.label = label;

        }



        public async Task <bool> Login(string User, string Password)
        {
           

            //error handling for if user or password is empty 
            if (Util.CheckUsernamePassword(User, Password))
            {
                //showing the error under the login button
                return await Util.LabelChangeAsync(label, "Please enter a username and password");
            }

            //attaching user and password to login json 
            IJson loginJson = new LoginJson
            {
                Email = User,
                Password = Password,
            };

            //set timeout for client
            client.Timeout = TimeSpan.FromSeconds(5);
            var response = await client.PostAsJsonAsync("https://localhost:8080/Api/Auth/Login", loginJson);
         
            //defining the cariable statuscode which was extracted from the request response
            var StatusCode = (Int32)response.StatusCode;

            //Checking the statuscode for all kinds of error statuscodes
            if (Util.CheckStatusCode(StatusCode) != "")
            {
                //getting the error code from method
                string errorString = (Util.CheckStatusCode(StatusCode));
                //showing the error under the login button
                return await Util.LabelChangeAsync(label, errorString);
            }

            //parsing the response text 
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());

            //getting the jwt login token from response text
            jwt = (string)json["jwt"];
            return true;


        }
        public async Task <bool> Register(string User, string Password)
        {

            //error handling for if user or password is empty 
            if (Util.CheckUsernamePassword(User, Password)) MessageBox.Show("Please enter username & password!");

            //attaching user and password to register json 
            IJson registerJson = new RegisterJson
            {
                Email = User,
                Password = Password,
            };

            //making the login request
            var response = await client.PostAsJsonAsync($"https://{_HostName}:{_Port}/Api/Auth/Register", registerJson);

            //defining the cariable statuscode which was extracted from the request response
            var StatusCode = (Int32)response.StatusCode;

            //Checking the statuscode for all kinds of error statuscodes
            if (Util.CheckStatusCode(StatusCode) != "")
            {
                MessageBox.Show((Util.CheckStatusCode(StatusCode)));
                return false;
            }

            //parsing the response text 
            JObject json = JObject.Parse(response.Content.ToString());

            //getting the jwt login token from response text
            jwt = (string)json["jwt"];
            return true;

        }





        

    }
}
