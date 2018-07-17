using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receive.Model
{
    class Connections
    {
        class Connection
        {
            private string Name { get; set; }
            private string IP { get; set; }

            public Connection(string name,string ip)
            {
                Name = name;
                IP = ip;
            }
        }
        List<Connection> connections=new List<Connection>();


        public void AddConnection(string name,string ip)
        {
            connections.Add(new Connection(name,ip));
        }
    }
}
