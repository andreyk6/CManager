using System.ComponentModel;
using System.Windows.Controls;

namespace CertifyMe.Client.ViewModel
{
    public interface IPageViewModel: INotifyPropertyChanged
    {
        IWindowViewModel Window { get; }
        Page Page { get; }
    }
}