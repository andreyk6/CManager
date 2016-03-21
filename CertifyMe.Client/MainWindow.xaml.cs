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
        UserServiceClient userService = new UserServiceClient();

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                User user = new User();
                user.Age = 18 + i;
                user.FirstName = "User1";
                user.LastName = "Generated" + i;
                user.Id = userService.Add(user);
            }
            var users = userService.GetAll();
            users = null;
            users = null;
        }
    }
}
