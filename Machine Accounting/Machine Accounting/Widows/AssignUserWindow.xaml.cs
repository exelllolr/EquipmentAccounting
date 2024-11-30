using System.Linq;
using System.Windows;
using Machine_Accounting.Models;
using MachineAccounting.Models;

namespace MachineAccounting.Views
{
    public partial class AssignUserWindow : Window
    {
        private readonly MachineAccountingEntities _context;

        public AssignUserWindow(Machine_Accounting.Models.Equipment selectedEquipment)
        {
            InitializeComponent();

            // Инициализация контекста базы данных
            _context = new MachineAccountingEntities();

            // Загрузка данных в ComboBox
            LoadEquipmentData();
            LoadUserData();
        }

        private void LoadEquipmentData()
        {
            // Загрузка списка доступной техники
            var equipmentList = _context.Equipment
                .Where(e => e.Status == "Доступно") // Отображаем только доступную технику
                .ToList();

            EquipmentComboBox.ItemsSource = equipmentList;
            EquipmentComboBox.DisplayMemberPath = "Name"; // Отображаем название техники
            EquipmentComboBox.SelectedValuePath = "Id"; // Храним идентификатор
        }

        private void LoadUserData()
        {
            // Загрузка списка пользователей
            var userList = _context.Users.ToList();

            UserComboBox.ItemsSource = userList;
            UserComboBox.DisplayMemberPath = "FullName"; // Отображаем имя пользователя
            UserComboBox.SelectedValuePath = "Id"; // Храним идентификатор
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранных значений
            var selectedEquipmentId = EquipmentComboBox.SelectedValue;
            var selectedUserId = UserComboBox.SelectedValue;

            if (selectedEquipmentId == null || selectedUserId == null)
            {
                MessageBox.Show("Выберите технику и пользователя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Обновление статуса техники и закрепление за пользователем
            var equipment = _context.Equipment.Find(selectedEquipmentId);
            var user = _context.Users.Find(selectedUserId);

            if (equipment != null && user != null)
            {
                equipment.Status = "Закреплено";

                _context.SaveChanges();

                MessageBox.Show($"Техника \"{equipment.Name}\" успешно закреплена за пользователем \"{user.FullName}\".", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка при закреплении техники. Повторите попытку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие окна
            Close();
        }
    }
}

