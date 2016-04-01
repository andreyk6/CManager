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
    public class LoginPageViewModel : PageViewModel
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

        public LoginPageViewModel(Page page, IWindowViewModel window) : base(page, window)
        {
            _userService = new UserServiceClient();
            SignIn = new ActionButtonCommand(this, _signInExecute, _signInCanExecute);
            Register = new ActionButtonCommand(this, _registerExecute, _registerCanExecute);
        }

        public ActionButtonCommand Register { get; set; }
        private void _registerExecute()
        {
            Window.CurrentView = new RegistrationPage(Window);
        }
        private bool _registerCanExecute()
        {
            return true;
        }

        public ActionButtonCommand SignIn { get; set; }
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
            Guid userId  = _userService.GetUserByCredentials(UserName, Password);
            if (userId != Guid.Empty)
            {
                Window.CurrentView = new UserHomePage();
            }
            else
            {
                //notify user about login result
            }
        }
    }
}
