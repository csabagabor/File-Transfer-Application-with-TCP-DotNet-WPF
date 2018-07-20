using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Receive.Model;

namespace Receive
{
    /// <summary>
    /// Interaction logic for WindowDeleteConnection.xaml
    /// </summary>
    public partial class WindowDeleteConnection : Window
    {
        public WindowDeleteConnection()
        {
            InitializeComponent();
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            string name = textBox_delete.Text;
            if (StoredConnections.GetConnection(name) != null)
            {
                StoredConnections.RemoveConnection(name);
                label_delete_msg.Content = "Connection deleted succesfully";
            }
            else label_delete_msg.Content = "Connection does not exist";
        }
    }
}
