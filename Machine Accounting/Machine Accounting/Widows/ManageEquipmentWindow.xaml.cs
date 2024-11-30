using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Machine_Accounting.Models;

namespace MachineAccounting.Views
{
    public partial class ManageEquipmentWindow : Window
    {
        private readonly MachineAccountingEntities _context;

        public ManageEquipmentWindow()
        {
            InitializeComponent();
            _context = new MachineAccountingEntities();
            LoadEquipment();
        }

        // Загрузка данных о технике в DataGrid
        private void LoadEquipment()
        {
            EquipmentDataGrid.ItemsSource = _context.Equipment.ToList();
        }

        // Добавление техники
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addEquipmentWindow = new AddEquipmentWindow();
            if (addEquipmentWindow.ShowDialog() == true)
            {
                LoadEquipment(); // Обновить данные после добавления
            }
        }

        // Удаление выбранной техники
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem is Equipment selectedEquipment)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить технику '{selectedEquipment.Name}'?",
                                             "Подтверждение удаления",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _context.Equipment.Remove(selectedEquipment);
                    _context.SaveChanges();
                    LoadEquipment(); // Обновить данные после удаления
                    MessageBox.Show("Техника успешно удалена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите технику для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Изменение статуса техники
        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem is Equipment selectedEquipment)
            {
                var newStatus = selectedEquipment.Status == "Доступно" ? "Недоступно" : "Доступно";
                selectedEquipment.Status = newStatus;

                _context.SaveChanges();
                LoadEquipment(); // Обновить данные после изменения
                MessageBox.Show($"Статус техники изменён на '{newStatus}'.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите технику для изменения статуса.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Закрепление техники за пользователем
        private void AssignToUser_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem is Equipment selectedEquipment)
            {
                // Открываем окно выбора пользователя
                var assignUserWindow = new AssignUserWindow(selectedEquipment);
                if (assignUserWindow.ShowDialog() == true)
                {
                    LoadEquipment(); // Обновить данные после закрепления
                }
            }
            else
            {
                MessageBox.Show("Выберите технику для закрепления за пользователем.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
