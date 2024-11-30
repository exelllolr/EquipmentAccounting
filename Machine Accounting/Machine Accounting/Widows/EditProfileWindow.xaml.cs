using System.Windows;
using Microsoft.Win32;
using System.IO;
using Machine_Accounting.Models;

namespace MachineAccounting.Views
{
    public partial class EditProfileWindow : Window
    {
        private readonly Users _currentUser;
        private readonly MachineAccountingEntities _context = new MachineAccountingEntities();

        public EditProfileWindow(Users user)
        {
            InitializeComponent();
            _currentUser = user;
            FullNameTextBox.Text = _currentUser.FullName;
        }

        public EditProfileWindow()
        {
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение изменений
            _currentUser.FullName = FullNameTextBox.Text;

            _context.Entry(_currentUser).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            MessageBox.Show("Профиль успешно обновлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void ChangeAvatar_Click(object sender, RoutedEventArgs e)
        {
            // Загрузка аватарки
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                byte[] avatar = File.ReadAllBytes(openFileDialog.FileName);

                MessageBox.Show("Аватарка успешно изменена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}