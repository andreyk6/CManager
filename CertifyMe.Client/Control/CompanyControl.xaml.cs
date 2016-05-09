using CertifyMe.Client.CompanyServiceReference;
using CertifyMe.Client.View;
using MaterialDesignThemes.Wpf;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CertifyMe.Client.Control
{
    /// <summary>
    /// Interaction logic for CompanyControl.xaml
    /// </summary>
    public partial class CompanyControl : UserControl
    {
        [Bindable(true)]
        public Visibility AdminButtonsVisibility
        {
            get { return (Visibility)GetValue(AdminButtonsVisibilityProperty); }
            set { SetValue(AdminButtonsVisibilityProperty, value); }
        }

        public static readonly DependencyProperty AdminButtonsVisibilityProperty =
            DependencyProperty.Register("AdminButtonsVisibility", typeof(Visibility),
              typeof(CompanyControl), new PropertyMetadata(Visibility.Collapsed));

        private Company CurrentCompany
        {
            get
            {
                return (Company)DataContext;
            }
        }

        public CompanyControl()
        {
            InitializeComponent();
        }

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            var companyViewWindow = new CompanyViewWindow(CurrentCompany.Id);
            companyViewWindow.Show();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyServiceClient companyService = new CompanyServiceClient())
            {
                if (companyService.RemoveById(CurrentCompany.Id))
                {
                    this.Visibility = Visibility.Collapsed;
                }
            }
        }

        private async void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            using (CompanyServiceClient companyService = new CompanyServiceClient())
            {
                if (companyService.Update(CurrentCompany))
                {
                    this.DataContext = Visibility.Collapsed;
                }
            }
        }

        private void EditDialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            //Close button event
            if (!Equals(eventArgs.Parameter, true)) return;

            //Data validation

            if (!UpdateCompanyInfo())
            {
                eventArgs.Cancel();
            }
        }

        private bool UpdateCompanyInfo()
        {
            var oldName = CurrentCompany.Name;
            var oldDescription = CurrentCompany.Description;
            CurrentCompany.Name = EditDialog_Name.Text;
            CurrentCompany.Description = EditDialog_Description.Text;
            using (CompanyServiceClient companyService = new CompanyServiceClient())
            {
                if (!companyService.Update(CurrentCompany))
                {
                    CurrentCompany.Name = oldName;
                    CurrentCompany.Description = oldDescription;
                    return false;
                }
            }
            return true;
        }
    }
}
