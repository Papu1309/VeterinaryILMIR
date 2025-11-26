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
using Veterinary.Connection;
using Veterinary.Properties;

namespace Veterinary.Win
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        //DB.User u = new DB.User();

        public User user {  get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnVhodd_Click(object sender, RoutedEventArgs e)
        {
            RegisterUser(loginTxb.Text, parolTxb.Password);
            NavigationService.Navigate(new UserPage(user));
        }
       
        private void RegisterUser(string email, string password)
        {
            User users = new User();
            users.login = email;
            users.password = password;
            DB.vet.User.Add(users);
            DB.vet.SaveChanges();
        }
    }
}
