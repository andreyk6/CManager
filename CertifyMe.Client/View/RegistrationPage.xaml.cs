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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        RegistrationPageViewModel model;
        public RegistrationPage()
        {
            InitializeComponent();
            model = new RegistrationPageViewModel();
            this.DataContext = model;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (model.SignUpExecute())
            {
                NavigationService.Navigate(new LoginPage());
            }
            else
            {
                MessageBox.Show("Can't register the user");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
