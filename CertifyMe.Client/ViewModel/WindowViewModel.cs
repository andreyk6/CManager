﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CertifyMe.Client.ViewModel
{
    public class WindowViewModel : IWindowViewModel
    {
        private Page _currentView;
        public Page CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                if (value == _currentView)
                    return;

                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
