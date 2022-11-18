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
                _reader = new StreamReader(_ns);
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
            //          check if username and password are empty

            //adding byte data for request
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("{"+$"\"email:\":\"{User}\",\"password\":\"{Password}\"" +"}");
            _ns.Write(data,0,data.Length);
            // Buffer to store the response bytes.
            data = new Byte[256];
            String responseData = String.Empty;
            Int32 bytes = _ns.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

            //TODO: Get status code
            if (responseData.Contains($"{User}")){
                MessageBox.Show("Logged in successfully!");

            } else if (responseData.Contains("Wrong"))
            {
                MessageBox.Show("Wrong username or password! \n");
            }

        }

    }
}
