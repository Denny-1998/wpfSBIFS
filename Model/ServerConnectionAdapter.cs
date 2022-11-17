using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
            _client = await cb.Connect();
        }



        public async Task Login(string User, string Password)
        {
            //do stuff
        }

    }
}
