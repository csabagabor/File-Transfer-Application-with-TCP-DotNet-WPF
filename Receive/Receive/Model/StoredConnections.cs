using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Receive.Model
{
    [Serializable()]
    public class Connection
    {
        public string Name { get; set; }
        public string IP { get; set; }

        public Connection(string name, string ip)
        {
            Name = name;
            IP = ip;
        }

        public override string ToString()
        {
            return Name + " " + IP;
        }

        public override bool Equals(object obj)
        {
            var connection = obj as Connection;
            return connection != null &&
                   Name == connection.Name &&
                   IP == connection.IP;
        }
    }

    public static class StoredConnections
    {
        private static List<Connection> Connections = new List<Connection>();

        static StoredConnections()
        {
            LoadConnections();
        }

        public static List<Connection> getConnections()
        {
            return Connections;
        }

        public static void AddConnection(string name, string ip)
        {
            Connections.Add(new Connection(name, ip));
            SaveConnections();
        }

        public static void RemoveConnection(string name)
        {
            Connections.Remove(GetConnection(name));
            SaveConnections();
        }

        public static Connection GetConnection(string name)
        {
            foreach (Connection con in Connections)
            {
                if (con.Name.Equals(name))
                    return con;
            }

            return null;
        }

        public static Connection GetConnection(int id)
        {
            if (id < Connections.Count)
                return Connections[id];

            return null;
        }

        public static Connection GetConnectionbyIp(string ip)
        {
            foreach (Connection con in Connections)
            {
                if (con.IP.Equals(ip))
                    return con;
            }

            return null;
        }

        public static void SaveConnections()
        {
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, Connections);
                }
            }
            catch (IOException)
            {
            }
        }

        public static void LoadConnections()
        {
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    Connections = (List<Connection>) bin.Deserialize(stream);
                    foreach (Connection connection in Connections)
                    {
                        Console.WriteLine(connection.ToString());
                    }
                }
            }
            catch (IOException)
            {

            }
        }
    }
}
