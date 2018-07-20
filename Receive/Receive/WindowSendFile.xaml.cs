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
using Microsoft.Win32;
using Receive.Controller;
using Receive.Model;

namespace Receive
{
    /// <summary>
    /// Interaction logic for WindowSendFile.xaml
    /// </summary>
    public partial class WindowSendFile : Window
    {
        private Send send;
        public string SendingFilePath = string.Empty;

        public WindowSendFile()
        {
            InitializeComponent();
            InitComboBox();
            send = new Send(this);
        }

        private void InitComboBox()
        {
            foreach (Connection con in StoredConnections.getConnections())
            {
                comboBox_connection.Items.Add(con);
            }
            
        }
        
        private void button_browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Dlg = new OpenFileDialog();
            Dlg.Filter = "All Files (*.*)|*.*";
            Dlg.CheckFileExists = true;
            Dlg.Title = "Choose a File";
            Dlg.InitialDirectory = @"C:\";
            if (Dlg.ShowDialog() == true)
            {
                SendingFilePath = Dlg.FileName;
                label_send.Content = Dlg.FileName;
            }
        }

        private void button_send_Click(object sender, RoutedEventArgs e)
        {
            if (SendingFilePath != string.Empty)
            {
                send.SendTCP(SendingFilePath, StoredConnections.GetConnection(comboBox_connection.SelectedIndex).IP, 12345);
            }
            else
                MessageBox.Show("Select a file", "Warning");
        }

        public ProgressBar GetProgressBar()
        {
            return progress_bar;
        }

        public Label GetLabelMsg()
        {
            return label_msg;
        }


    }
}
