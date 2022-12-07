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
using System.Windows.Input;
using System.Drawing;
using System.Threading;

namespace wpfSBIFS.Model {

    public class ServerConnectionAdapter
    {


        HttpClient client;
        Label label;
        string _HostName;
        int _Port;
        string jwt;


        public ServerConnectionAdapter(string HostName, int Port, HttpClient client, Label label)
        {
            _HostName = HostName;
            _Port = Port;
            this.client = client;
            this.label = label;

        }



        public async Task<bool> Login(string User, string Password)
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
            client.Timeout = TimeSpan.FromSeconds(10);
            HttpResponseMessage response;
            try
            {
                response = await client.PostAsJsonAsync("https://localhost:8080/Api/Auth/Login", loginJson);
            }
            catch (TaskCanceledException)
            {
                return await Util.LabelChangeAsync(label, "The request timed out!");

            }
            catch (HttpRequestException)
            {
                return await Util.LabelChangeAsync(label, "The server is not reachable!");
            }

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
            //set jwt token as default header in client
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            return true;


        }
        public async Task<bool> Register(string User, string Password)
        {
            if (Password == "")
            {
                Password = Util.GeneratePassword();
            }
            //error handling for if user or password is empty  TODO: use other label
            if (Util.CheckUsernamePassword(User, Password))
            {
                //showing the error under the login button
                return await Util.LabelChangeAsync(label, "Please enter a username and password");
            }

            //attaching user and password to register json 
            IJson registerJson = new RegisterJson
            {
                Email = User,
                Password = Password,
            };

            //TODO: use other label
           
            HttpResponseMessage response;
            try { 
                
                 response = await client.PostAsJsonAsync($"https://{_HostName}:{_Port}/Api/Auth/Register", registerJson);
                }
            catch (TaskCanceledException)
                {
                return await Util.LabelChangeAsync(label, "The request timed out!");

                }
            catch (HttpRequestException)
                {
                return await Util.LabelChangeAsync(label, "The server is not reachable!");
                }

            //defining the cariable statuscode which was extracted from the request response
            var StatusCode = (Int32)response.StatusCode;

            //Checking the statuscode for all kinds of error statuscodes TODO: use own label
            if (Util.CheckStatusCode(StatusCode) != "")
            {
                //getting the error code from method
                string errorString = (Util.CheckStatusCode(StatusCode));
                //showing the error under the login button
                return await Util.LabelChangeAsync(label, errorString);
            }

            
            return true;

        }
        public async Task<string> GetUserCount(string User, string Password)
        {
            //set timeout for client
            client.Timeout = TimeSpan.FromSeconds(10);
            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync("https://localhost:8080/Api/Auth/Login");
            }
            catch (TaskCanceledException) { 
                return "";
            }
            catch (HttpRequestException)
            {
                return "";
            }

            //defining the cariable statuscode which was extracted from the request response
            var StatusCode = (Int32)response.StatusCode;

            //Checking the statuscode 
            if (Util.CheckStatusCode(StatusCode) != "")
            {
                return "";
            }

            //parsing the response text 
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());
            
            //returning the usercount as string
            return (string)json["countUsers"]; ;


        }
    }
}
