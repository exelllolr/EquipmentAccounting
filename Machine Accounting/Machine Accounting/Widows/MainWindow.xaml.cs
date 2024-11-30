using Machine_Accounting.Models;
using System.Windows;

namespace Machine_Accounting.Widows
{
   
    public partial class MainWindow : Window
    {
        private readonly Users _user; // Хранит информацию о текущем пользователе

        public MainWindow(Users user)
        {
            InitializeComponent();
            _user = user; // Инициализируем пользователя
        }
        // Обработчик для кнопки "Добавить пользователя"
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            // Логика для добавления пользователя
            MessageBox.Show("Добавление пользователя...");
        }

        // Обработчик для кнопки "Редактировать профиль"
        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            // Логика для редактирования профиля
            MessageBox.Show("Редактирование профиля...");
        }

        // Обработчик для кнопки "Управление техникой"
        private void ManageEquipment_Click(object sender, RoutedEventArgs e)
        {
            // Логика для управления техникой
            MessageBox.Show("Управление техникой...");
        }

        // Обработчик для кнопки "Просмотр техники"
        private void ViewEquipment_Click(object sender, RoutedEventArgs e)
        {
            // Логика для просмотра техники
            MessageBox.Show("Просмотр техники...");
        }
    }
}
    