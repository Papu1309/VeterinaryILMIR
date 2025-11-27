using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static ObservableCollection<User> sotrudniks { get; set; }
        public User sotrudnik { get; private set; }



        public User user {  get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnVhodd_Click(object sender, RoutedEventArgs e)
        {
            user = RegisterUser(loginTxb.Text, parolTxb.Password);
            NavigationService.Navigate(new UserPage(user));
        }
       
        private User RegisterUser(string email, string password)
        {
            User users = new User();
            users.login = email;
            users.password = password;
            users.id_doctors = 3;
            DB.vet.User.Add(users);
            DB.vet.SaveChanges();
            return users;
        }
    }
}
