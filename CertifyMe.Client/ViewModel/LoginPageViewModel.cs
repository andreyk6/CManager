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
                OnPropertyChanged("SignInCanExecute");
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
                OnPropertyChanged("SignInCanExecute");
            }
        }

        public LoginPageViewModel()
        {
            _userService = new UserServiceClient();
        }

        public bool SignInCanExecute
        {
            get
            {
                if (string.IsNullOrEmpty(UserName) ||
                    string.IsNullOrEmpty(Password))
                {
                    return false;
                }
                return true;
            }
        }
        public bool SignInExecute()
        {
            //Request to the server
            Guid userId = _userService.GetUserByCredentials(UserName, Password);
            if (userId != Guid.Empty)
            {
                SystemUser.Instance.Id = userId;
                return true;
            }
            return false;
        }
    }
}
