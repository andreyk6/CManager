using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CertifyMe.Client.ViewModel
{
    public class PageViewModel : IPageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Page _page;
        public Page Page
        {
            get
            {
                return _page;
            }
            set
            {
                if (value == _page)
                    return;
                _page = value;
                OnPropertyChanged("Page");
            }
        }
        private IWindowViewModel _window;
        public IWindowViewModel Window
        {
            get
            {
                return _window;
            }
            set
            {
                if (value == _window)
                    return;
                _window = value;
                OnPropertyChanged("Window");
            }
        }


        public PageViewModel(Page page, IWindowViewModel window)
        {
            Page = page;
            Window = window;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
