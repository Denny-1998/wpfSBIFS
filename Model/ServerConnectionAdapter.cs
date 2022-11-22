using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpfSBIFS.Model
{
    public class ServerConnectionAdapter
    {
        
        TcpClient _client;
        NetworkStream _ns;
        StreamReader _reader;

        string _HostName;
        int _Port;


        public ServerConnectionAdapter(string HostName, int Port)
        {
            _HostName = HostName;
            _Port = Port;
            
            connect();
        }


        private async Task connect()
        {
            //build new connection
            ConnectionBuilder cb = new ConnectionBuilder();
            cb.AddHostname(_HostName);
            cb.AddPort(_Port);

            //connect 
            try
            {
                _client = await cb.Connect();
                _ns = _client.GetStream();
                _reader = new StreamReader(_ns, Encoding.UTF8);
            } 
            catch (Exception ex)
            {
                MessageBox.Show("something went wrong: \n\n" + ex.Message);
            }

        }



        public async Task Login(string User, string Password)
        {

            //error handling for if user or password is empty 
            if (User.Equals("") || Password.Equals(""))
            {
                MessageBox.Show("Please enter username");
                return;
            }


            //TODO: error handling
            //try around with headers
            var message = @"GET /api/Auth HTTP/1.1
Host: localhost" + "\r\n\r\n";


            //adding byte data for request
            Byte[] data = Encoding.UTF8.GetBytes(message);
            _ns.Write(data,0,data.Length);
            //getting response
            MessageBox.Show(_reader.ReadToEnd());

            /*
            //TODO: Get status code
            if (responseData.Contains($"{User}")){
                MessageBox.Show("Logged in successfully!");

            } else if (responseData.Contains("Wrong"))
            {
                MessageBox.Show("Wrong username or password! \n");
            }*/

        }

    }
}
