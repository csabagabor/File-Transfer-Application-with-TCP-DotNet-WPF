using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Receive.Model;

namespace Receive.ViewModel
{
    class ConnectionViewModel
    {
        public ObservableCollection<Connection> dt { get; set; }

        public void LoadConnections()
        {
            dt = new ObservableCollection<Connection>();
            foreach (Connection connection in StoredConnections.getConnections())
            {
                dt.Add(connection);
            }
        }
    }
}
