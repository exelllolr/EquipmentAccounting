//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Machine_Accounting.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EquipmentHistory
    {
        public int HistoryID { get; set; }
        public int EquipmentID { get; set; }
        public string Status { get; set; }
        public int AssignedUserID { get; set; }
        public System.DateTime ChangedAt { get; set; }
        public string ChangedBy { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual Users Users { get; set; }
    }
}
