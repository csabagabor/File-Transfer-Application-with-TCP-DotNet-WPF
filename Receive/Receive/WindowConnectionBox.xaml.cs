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
using System.Windows.Threading;
using Receive.Model;

namespace Receive
{
    /// <summary>
    /// Interaction logic for WindowConnectionBox.xaml
    /// </summary>
    public partial class WindowConnectionBox : Window
    {

        private const int REMOVE_LABEL_AFTER_SECONDS = 4;
        public WindowConnectionBox()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //add new connection
            string name = textBoxName.Text;
            string ip = textBoxIP.Text;
            
            
            Connection connection = new Connection(name,ip);
            if (name == "" || ip == "")
                label_succesfull.Content = "Empty input";
            else if (StoredConnections.getConnections().Contains(connection))
                label_succesfull.Content = "Duplicate Connection";
            else if (StoredConnections.GetConnection(name)!=null)
            {
                //connection exists, we ask the user if he wants to change it
                if (MessageBox.Show("Connection already exists, change it?", "Connection", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    StoredConnections.GetConnection(name).IP = ip;
                    label_succesfull.Content = "Connection modified";
                }
            }
            else
            {
                label_succesfull.Content = "Connection added succesfully";
                StoredConnections.AddConnection(name, ip);
            }


            clearInput();
            AddTimerEraseLabel();
        }

        private void clearInput()
        {
            textBoxName.Clear();
            textBoxIP.Clear();
        }

        private void AddTimerEraseLabel()
        {
            //after REMOVE_LABEL_AFTER_SECONDS seconds remove the label
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(REMOVE_LABEL_AFTER_SECONDS) };
            timer.Tick += (send, args) =>
            {
                label_succesfull.Content = "";
                timer.Stop();
            };
            timer.Start();
        }

        
    }
}
