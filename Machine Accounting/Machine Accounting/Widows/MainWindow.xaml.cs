using MachineAccounting.Views;
using System.Windows;

namespace Machine_Accounting.Widows
{
    public partial class MainWindow : Window
    {
        public MainWindow(Models.Users user)
        {
            InitializeComponent();
        }

        // Открытие окна для добавления пользователя
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var addUserWindow = new AddUserWindow(); 
            addUserWindow.ShowDialog(); // Открыть модально
        }

        // Открытие окна для редактирования профиля
        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            var editProfileWindow = new EditProfileWindow(); 
            editProfileWindow.ShowDialog();
        }

        // Открытие окна управления техникой
        private void ManageEquipment_Click(object sender, RoutedEventArgs e)
        {
            var manageEquipmentWindow = new ManageEquipmentWindow(); 
            manageEquipmentWindow.ShowDialog();
        }

        // Открытие окна просмотра техники
        private void ViewEquipment_Click(object sender, RoutedEventArgs e)
        {
            var equipmentWindow = new EquipmentWindow(); 
            equipmentWindow.ShowDialog();
        }
    }
}
