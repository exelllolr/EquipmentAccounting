using System.Windows;
using MachineAccounting.Models;

namespace MachineAccounting.Views
{
    public partial class AddEquipmentWindow : Window
    {
        private readonly AppDbContext _context;

        public AddEquipmentWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var equipment = new Equipment
            {
                Name = NameTextBox.Text,
                Model = ModelTextBox.Text,
                SerialNumber = SerialNumberTextBox.Text,
                Status = "Доступно"
            };

            _context.Equipment.Add(equipment);
            _context.SaveChanges();

            MessageBox.Show("Техника успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}


