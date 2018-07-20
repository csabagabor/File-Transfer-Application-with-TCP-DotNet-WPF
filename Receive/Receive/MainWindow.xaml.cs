using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Receive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Model.Receive receive = new Model.Receive();
        private int nr_dots = 0;

        public MainWindow()
        {
            InitializeComponent();
            //creating a timer that is used to display the 3 dots showing that the server is waiting
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,100);
            dispatcherTimer.Start();
        }


        /*
         * timer that is used to display the 3 dots showing that the server is waiting
         */
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (nr_dots <3)
            {
                nr_dots++;
                labelDot.Content += ".";
            }
            else
            {
                nr_dots = 0;
                labelDot.Content = "";
            }
            
        }

        /*
         *terminate the current thread running the main window
         * and the thread that handles connections as well
         */
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            receive.CloseConnection();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            receive.CloseConnection();
            this.Close();
        }

        private void AddConnection_Click(object sender, RoutedEventArgs e)
        {
            WindowConnectionBox window=new WindowConnectionBox();
            window.Show();
        }

        private void buttonShowConnections_Click(object sender, RoutedEventArgs e)
        {
            WindowShowConnections window=new WindowShowConnections();
            window.Show();
        }

        private void buttonDeleteConnection_Click(object sender, RoutedEventArgs e)
        {
            WindowDeleteConnection window = new WindowDeleteConnection();
            window.Show();
        }

        private void button_send_Click(object sender, RoutedEventArgs e)
        {
            WindowSendFile window = new WindowSendFile();
            window.Show();
        }
    }
}
