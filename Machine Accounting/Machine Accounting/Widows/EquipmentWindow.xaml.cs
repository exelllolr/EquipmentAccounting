using System.Linq;
using System.Windows;
using MachineAccounting.Models;

namespace MachineAccounting.Views
{
    public partial class EquipmentWindow : Window
    {
        private readonly AppDbContext _context;

        public EquipmentWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadEquipment();
        }

        private void LoadEquipment()
        {
            EquipmentDataGrid.ItemsSource = _context.Equipment.ToList();
        }
    }
}
