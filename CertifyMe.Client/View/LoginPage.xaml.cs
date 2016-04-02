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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        LoginPageViewModel model;

        public LoginPage()
        {
            InitializeComponent();
            model = new LoginPageViewModel();
            this.DataContext = model;
        }

        private void userPassword_KeyUp(object sender, KeyEventArgs e)
        {
            model.Password = ((PasswordBox)sender).Password;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPage());
        }

        private void Signin_Click(object sender, RoutedEventArgs e)
        {
            if (model.SignInExecute())
            {
                Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }
    }
}
