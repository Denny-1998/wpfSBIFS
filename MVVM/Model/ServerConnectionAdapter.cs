using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Json;
using wpfSBIFS.Tools;
using Newtonsoft.Json.Linq;
using wpfSBIFS.MVVM.ViewModel;
using System.Windows;

namespace wpfSBIFS.MVVM.Model
{
    public class ServerConnectionAdapter
    {
        private readonly HttpClient _client;
        private readonly string _hostName;
        private readonly int _port;
        private string? _jwt;

        public ServerConnectionAdapter(string hostName, int port, HttpClient client)
        {
            _hostName = hostName;
            _port = port;
            _client = client;
        }

        public async Task<bool> Login(string user, string password, LoginViewModel lvm)
        {

            //attaching user and password to login json 
            IJson loginJson = new LoginJson
            {
                Email = user,
                Password = password,
            };

            

            HttpResponseMessage response;

            response = await _client.PostAsJsonAsync("https://localhost:8080/Api/Auth/Login", loginJson);

            //defining the cariable statuscode which was extracted from the request response
            int statusCode = (int)response.StatusCode;

            //Checking the statuscode for all kinds of error statuscodes
            if (Util.CheckStatusCode(statusCode,200) != "")
            {
                //getting the error code from method
                string errorString = (Util.CheckStatusCode(statusCode,200));
                //showing the error under the login button
                lvm.Status = errorString;
                return  false;
            }

            //parsing the response text 
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());

            //getting the _jwt login token from response text
            _jwt = (string)json["jwt"];
            string authenticationCheck = (string)json["role"];
            if (authenticationCheck == "user")
            
            {
                lvm.Status = "You are not authorized to use this application";
                return false;
            }



            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwt);
            



            return true;
        }

        public async Task<bool> Register(string User, string Password, RegisterViewModel cuvm)
        {
            //attaching user and password to register json 
            IJson registerJson = new RegisterJson
            {
                Email = User,
                Password = Password,
            };

            HttpResponseMessage response;

            
            response = await _client.PostAsJsonAsync($"https://{_hostName}:{_port}/Api/Auth/Register", registerJson);

            //defining the cariable statuscode which was extracted from the request response
            int statusCode = (int)response.StatusCode;

            //Checking the statuscode for all kinds of error statuscodes TODO: use own label
            if (Util.CheckStatusCode(statusCode,204) != "")
            {
                //getting the error code from method
                string errorString = (Util.CheckStatusCode(statusCode,204));
                //showing the error under the login button
                cuvm.Status = errorString;
                return false;
            }

            return true;
        }
        public async Task<bool> DeleteUser(string User, DeleteUserViewModel cuvm)
        {   

            //attaching user and password to register json 
            IJsonDelete deleteJson = new DeleteJson
            {
                Email = User,
              
            };

            HttpResponseMessage response;

            response = await _client.PostAsJsonAsync($"https://{_hostName}:{_port}/Api/AdminUser/DeleteUser", deleteJson);

            //defining the cariable statuscode which was extracted from the request response
            int statusCode = (int)response.StatusCode;

            if (statusCode == 400 )
            {
                cuvm.Status = "User not found!";
                return false;
            }
            //Checking the statuscode for all kinds of error statuscodes TODO: use own label
            if (Util.CheckStatusCode(statusCode,204) != "")
            {
                //getting the error code from method
                string errorString = (Util.CheckStatusCode(statusCode,200));
                //showing the error under the login button
                cuvm.Status = errorString;
                return false;
            }

            return true;
        }

        public async Task<int> GetUserCount()
        {
            
            
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync("https://localhost:8080/Api/AdminUser/CountUsers");
            }
            catch (TaskCanceledException) { 
                return 0;
            }
            catch (HttpRequestException)
            {
                return 0;
            }

            //defining the cariable statuscode which was extracted from the request response
            int statusCode = (int)response.StatusCode;

            //Checking the statuscode 
            if (Util.CheckStatusCode(statusCode,200) != "")
            {
                return 0;
            }

            //parsing the response text 
            JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());

            //returning the usercount as string
            return (int)json["count"];
        }
    }
}
