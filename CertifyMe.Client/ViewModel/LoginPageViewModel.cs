using CertifyMe.Client.UserServiceReference;
using CertifyMe.Client.Utilities;
using CertifyMe.Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CertifyMe.Client.ViewModel
{
    public class LoginPageViewModel : ViewModelBase
    {
        private UserServiceClient _userService;

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value == _userName)
                    return;

                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password)
                    return;

                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public LoginPageViewModel(Page page) : base(page)
        {
            _userService = new UserServiceClient();
            SignIn = new NavigationButtonCommand(this, _signInExecute, _signInCanExecute);
            Register = new NavigationButtonCommand<LoginPageViewModel>(this, _registerExecute, _registerCanExecute);
        }

        public NavigationButtonCommand<LoginPageViewModel> Register { get; set; }
        private void _registerExecute(LoginPageViewModel model)
        {
            model.Page.NavigationService.Navigate(new RegistrationPage());
        }
        private bool _registerCanExecute(LoginPageViewModel model)
        {
            return true;
        }

        public NavigationButtonCommand SignIn { get; set; }
        private bool _signInExecuting;

        public bool SignInExecuting
        {
            get { return _signInExecuting; }
            set
            {
                if (value == _signInExecuting)
                    return;

                _signInExecuting = value;
                OnPropertyChanged("SignInExecuting");
            }
        }
        private bool _signInCanExecute()
        {
            if (string.IsNullOrEmpty(UserName) ||
                string.IsNullOrEmpty(Password))
            {
                return false;
            }
            return true;
        }
        private void _signInExecute()
        {
            SignInExecuting = false;
            //Request to the server
            bool authResult = true;
            if (authResult)
            {
                Page.NavigationService.Navigate(new UserHomePage());
            }
            else
            {
                //notify user about login result
            }
        }
    }
}
