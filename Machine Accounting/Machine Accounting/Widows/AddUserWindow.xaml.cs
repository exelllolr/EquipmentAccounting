using System.Windows;
using MachineAccounting.Models;

namespace MachineAccounting.Views
{
    public partial class AddUserWindow : Window
    {
        private readonly AppDbContext _context;

        public AddUserWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var user = new Users
            {
                FullName = FullNameTextBox.Text,
                Username = UsernameTextBox.Text,
                Password = PasswordBox.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            MessageBox.Show("Пользователь успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}

