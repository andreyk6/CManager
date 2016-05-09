using System;
using System.ComponentModel;

namespace CertifyMe.Client.ViewModel
{
    public class SystemUser : INotifyPropertyChanged
    {

        #region [ Singleton ]
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
        #endregion

        #region [ Refresh event ]
        public event RefreshEventHandler RefreshEvent;
        public void Refresh()
        {
            RefreshEvent(null);
        }
        #endregion

        #region [ INotifyPropertyChanged ]
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null && propertyName != null)
            {
                PropertyChanged(Instance, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                    return;
                _id = value;
                OnPropertyChanged("Id");
            }
        }
    }
}

