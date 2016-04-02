using CertifyMe.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CertifyMe.Client.Utilities
{
    public class ActionButtonCommand : ICommand
    {
        private ViewModelBase _model;
        private CanExecuteDelegate _canExecute;
        private ExecuteDelegate _execute;

        public event EventHandler CanExecuteChanged;

        public ActionButtonCommand(ViewModelBase viewModel, ExecuteDelegate execute, CanExecuteDelegate canExecute)
        {
            _model = viewModel;
            _execute = execute;
            _canExecute = canExecute;
            _model.PropertyChanged += (s, e) =>
            {
                if (this.CanExecuteChanged != null)
                {
                    this.CanExecuteChanged(this, new EventArgs());
                }
            };
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
