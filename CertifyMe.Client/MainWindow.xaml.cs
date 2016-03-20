using CertifyMe.Client.ServiceReference1;
using System;
using System.Collections.Generic;
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

namespace CertifyMe.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            User user = new User();
            user.Age = 10;
            user.FirstName = "Andrii";
            user.LastName = "Konovalenko";
            var userService = new UserServiceClient();
            user.Id = userService.Add(user);

            var userFromServer = userService.GetById(user.Id);
            //var user = userService; 
        }
    }
}
