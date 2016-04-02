using CertifyMe.Client.UserServiceReference;
using CertifyMe.Client.Utilities;
using CertifyMe.Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CertifyMe.Client.ViewModel
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        private UserServiceClient _userService;

        public UserInfo UserInfo
        {
            get
            {
                return _userInfo;
            }
            set
            {
                if (value == _userInfo)
                    return;
                _userInfo = value;
                OnPropertyChanged("UserInfo");
            }
        }
        private UserInfo _userInfo;

        public RegistrationPageViewModel()
        {
            _userService = new UserServiceClient();
            _userInfo = new UserInfo();
        }

        public bool SignUpCanExecute
        {
            get
            {
                if (string.IsNullOrEmpty(Login) ||
                    string.IsNullOrEmpty(Password) ||
                    string.IsNullOrEmpty(FirstName) ||
                    string.IsNullOrEmpty(LastName) ||
                    Age < 18 || Age > 150)
                {
                    return false;
                }
                return true;
            }
        }
        public bool SignUpExecute()
        {
            if (SignUpCanExecute)
            {
                //Request to the server
                var userId = _userService.Add(_userInfo);
                if (userId != Guid.Empty)
                {
                    return true;
                    //Window.CurrentView = new LoginPage(Window);
                }
            }
            return false;
        }

        public string Login
        {
            get { return UserInfo.Login; }
            set
            {
                if (value == UserInfo.Login)
                    return;
                UserInfo.Login = value;
                OnPropertyChanged("Login");
                OnPropertyChanged("SignUpCanExecute");
            }
        }
        public string Password
        {
            get { return UserInfo.Password; }
            set
            {
                if (value == UserInfo.Password)
                    return;
                UserInfo.Password = value;
                OnPropertyChanged("Password");
                OnPropertyChanged("SignUpCanExecute");
            }
        }
        public string FirstName
        {
            get { return UserInfo.FirstName; }
            set
            {
                if (value == UserInfo.FirstName)
                    return;
                UserInfo.FirstName = value;
                OnPropertyChanged("FirstName");
                OnPropertyChanged("SignUpCanExecute");
            }
        }
        public string LastName
        {
            get { return UserInfo.LastName; }
            set
            {
                if (value == UserInfo.LastName)
                    return;
                UserInfo.LastName = value;
                OnPropertyChanged("LastName");
                OnPropertyChanged("SignUpCanExecute");
            }
        }
        public int Age
        {
            get { return UserInfo.Age; }
            set
            {
                if (value == UserInfo.Age)
                    return;
                UserInfo.Age = value;
                OnPropertyChanged("Age");
                OnPropertyChanged("SignUpCanExecute");
            }
        }
    }
}
