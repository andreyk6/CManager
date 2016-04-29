using System;
using System.ComponentModel;

namespace CertifyMe.Client.ViewModel
{
    public class SystemUser : INotifyPropertyChanged
    {
        protected SystemUser() { }

        private static SystemUser _instance;
        public static SystemUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SystemUser();
                return _instance;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null && propertyName != null)
            {
                PropertyChanged(Instance, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set {
                if (_id == value)
                    return;
                _id = value;
                OnPropertyChanged("Id");
            }
        }
    }
}

