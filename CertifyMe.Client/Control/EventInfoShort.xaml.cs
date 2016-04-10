using CertifyMe.Client.EventServiceReference;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CertifyMe.Client.Control
{
    /// <summary>
    /// Interaction logic for EventInfoShort.xaml
    /// </summary>
    public partial class EventInfoShort : UserControl
    {
        public EventInfoShort()
        {
            InitializeComponent();
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((this.DataContext as Event).Name);
        }
    }
}
