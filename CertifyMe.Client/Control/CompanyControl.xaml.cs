using CertifyMe.Client.CompanyServiceReference;
using CertifyMe.Client.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CertifyMe.Client.Control
{
    /// <summary>
    /// Interaction logic for CompanyControl.xaml
    /// </summary>
    public partial class CompanyControl : UserControl
    {
        [Bindable(true)]
        public Visibility RemoveButtonVisibility
        {
            get { return (Visibility)GetValue(RemoveButtonVisibilityProperty); }
            set { SetValue(RemoveButtonVisibilityProperty, value); }
        }

        public static readonly DependencyProperty RemoveButtonVisibilityProperty =
            DependencyProperty.Register("RemoveButtonVisibility", typeof(Visibility),
              typeof(CompanyControl), new PropertyMetadata(Visibility.Collapsed));

        public CompanyControl()
        {
            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var companyViewWindow = new CompanyViewWindow(((Company)DataContext).Id);
            companyViewWindow.Show();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            CompanyServiceClient companyService = new CompanyServiceClient();
            if (companyService.RemoveById(((Company)DataContext).Id))
            {
                this.Visibility = Visibility.Collapsed;
            }
        }
    }
}
