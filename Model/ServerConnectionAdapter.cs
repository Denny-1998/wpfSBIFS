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
            //TODO
            //do stuff
        }

    }
}
