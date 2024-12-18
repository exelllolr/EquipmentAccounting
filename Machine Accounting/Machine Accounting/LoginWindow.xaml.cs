﻿using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using Machine_Accounting.Models;
using Machine_Accounting.Widows;

namespace MachineAccounting.Views
{
    public partial class LoginWindow : Window
    {
        private readonly MachineAccountingEntities _context;

        public LoginWindow()
        {
            InitializeComponent();
            _context = new MachineAccountingEntities(); // Инициализация контекста
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что поля заполнены
            if (string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Password.Password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.");
                return;
            }

            // Проверяем данные в базе
            var user = _context.Users
                .FirstOrDefault(u => u.Email == Username.Text && u.Password == Password.Password);

            if (user != null)
            {
                MessageBox.Show($"Добро пожаловать!");
                // Открываем главное окно с передачей объекта пользователя
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private void BHelp_Click(object sender, RoutedEventArgs e)
        {
            // Переход в MainWindow без проверки пользователя
            MainWindow mainWindow = new MainWindow(null); // Передаем null, так как пользователь не авторизован
            mainWindow.Show();
            this.Close();
        }
    }
}

