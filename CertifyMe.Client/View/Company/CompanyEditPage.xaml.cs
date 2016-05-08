using CertifyMe.Client.CompanyServiceReference;
using CertifyMe.Client.ViewModel;
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

namespace CertifyMe.Client.View
{
    /// <summary>
    /// Interaction logic for CompanyEditPage.xaml
    /// </summary>
    public partial class CompanyEditPage : Page
    {
        public CompanyEditPage()
        {
            InitializeComponent();
            DataContext = new CompanyEditViewModel(((Company)DataContext).Id);
        }
        public CompanyEditPage(Guid id)
        {
            InitializeComponent();
            DataContext = new CompanyEditViewModel(id);
        }
    }
}
