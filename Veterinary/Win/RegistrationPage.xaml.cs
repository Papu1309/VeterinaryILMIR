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


namespace Veterinary.Win
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public static ObservableCollection<User> sotrudniks { get; set; }
        public static User AuthorisationSotr(string login, string password)
        {
            sotrudniks = new ObservableCollection<User>(DB.vet.User.ToList());
            var userExists = sotrudniks.Where(sotrudniks => sotrudniks.login == login && sotrudniks.password == password).FirstOrDefault();
            if (userExists != null)
            {
                return userExists;
            }
            else
            {
                return userExists;
            }
        }
        public static User user;
        public RegistrationPage()
        {
            InitializeComponent();
        }
        public User sotrudnik { get; private set; }

        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTxb.Text.Trim();
            string password = parolTxb.Password.Trim();
            user = AuthorisationSotr(login, password);
            sotrudnik = AuthorisationSotr(login, password);
            if (sotrudnik != null)
            {
                NavigationService.Navigate(new UserPage(user));

            }
            else MessageBox.Show("Логин или пароль неверный", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnVhod_Копировать_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

    }
}
