using Machine_Accounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineAccounting.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public int? AssignedUserId { get; set; } // Закрепленный пользователь (nullable)
        public virtual Users AssignedUser { get; set; } // Связь с таблицей пользователей
        
    }
}
