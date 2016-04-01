using CertifyMe.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CertifyMe.Client.Utilities
{
    public delegate void ExecuteDelegate<T>(T model);
    public delegate bool CanExecuteDelegate<T>(T model);

    public delegate void ExecuteDelegate();
    public delegate bool CanExecuteDelegate();

    public class NavigationButtonCommand<T> : ICommand where T : IPageViewModel
    {
        private T _model;
        private CanExecuteDelegate<T> _canExecute;
        private ExecuteDelegate<T> _execute;

        public event EventHandler CanExecuteChanged;

        public NavigationButtonCommand(T viewModel, ExecuteDelegate<T> execute, CanExecuteDelegate<T> canExecute)
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

        public NavigationButtonCommand(T viewModel, ExecuteDelegate execute, CanExecuteDelegate canExecute)
            : this(viewModel,
                 new ExecuteDelegate<T>((m) => { execute(); }),
                 new CanExecuteDelegate<T>((m) => { return canExecute(); }))
        { }

        public bool CanExecute(object parameter)
        {
            return _canExecute(_model);
        }

        public void Execute(object parameter)
        {
            _execute(_model);
        }
    }


    public class NavigationButtonCommand : ICommand
    {
        private CanExecuteDelegate _canExecute;
        private ExecuteDelegate _execute;
        private IPageViewModel _viewModel;
        public event EventHandler CanExecuteChanged;
        public NavigationButtonCommand(IPageViewModel viewModel, ExecuteDelegate execute, CanExecuteDelegate canExecute)
        {
            _viewModel = viewModel;
            _execute = execute;
            _canExecute = canExecute;
            _viewModel.PropertyChanged += (s, e) =>
            {
                if (this.CanExecuteChanged != null)
                {
                    viewModel.Page.Dispatcher.Invoke(() =>
                    {
                        this.CanExecuteChanged(this, new EventArgs());
                    });
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
