using System;
using System.Collections.Generic;
using System.Data;
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
using Receive.ViewModel;

namespace Receive
{
    /// <summary>
    /// Interaction logic for WindowShowConnections.xaml
    /// </summary>
    public partial class WindowShowConnections : Window
    {
        public WindowShowConnections()
        {
            InitializeComponent();
            var connectionViewModel = new ConnectionViewModel();
            connectionViewModel.LoadConnections();
            this.DataContext = connectionViewModel;
        }

        
    }
}
