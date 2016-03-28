using System.ComponentModel;
using System.Windows.Controls;

namespace CertifyMe.Client.ViewModel
{
    public interface IWindowViewModel: INotifyPropertyChanged
    {
        Page CurrentView { get; set; }
    }
}