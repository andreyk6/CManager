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
    public class RegistrationPageViewModel : PageViewModel
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

        public RegistrationPageViewModel(Page page, IWindowViewModel window) : base(page, window)
        {
            _userService = new UserServiceClient();
            _userInfo = new UserInfo();
            SignUp = new ActionButtonCommand(this, _signUpExecute, _signUpCanExecute);
        }

        public ActionButtonCommand SignUp { get; set; }
        private bool _signUpCanExecute()
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
        private void _signUpExecute()
        {
            SignUpExecuting = false;
            //Request to the server
            var userId = _userService.Add(_userInfo);
            if (userId != Guid.Empty)
            {
                Window.CurrentView = new LoginPage(Window);
            }
            else
            {
            }
        }

        public bool SignUpExecuting
        {
            get { return _signUpExecuting; }
            set
            {
                if (value == _signUpExecuting)
                    return;

                _signUpExecuting = value;
                OnPropertyChanged("SignUpExecuting");
            }
        }
        private bool _signUpExecuting;

        public string Login
        {
            get { return UserInfo.Login; }
            set
            {
                if (value == UserInfo.Login)
                    return;
                UserInfo.Login = value;
                OnPropertyChanged("Login");
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
            }
        }
    }
}
