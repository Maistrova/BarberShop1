//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarberShop1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeTable()
        {
            this.RecordTable = new HashSet<RecordTable>();
        }
    
        public int PersonalNumberEmployee { get; set; }
        public string SurnameEmployee { get; set; }
        public string NameEmployee { get; set; }
        public string PatronymicEmployee { get; set; }
        public int PNPostEmployee { get; set; }
        public Nullable<int> PNImageEmployee { get; set; }
        public string LoginEmployee { get; set; }
        public string PasswordEmployee { get; set; }
        public int PNPaulEmployee { get; set; }
    
        public virtual ImageEmployeeTable ImageEmployeeTable { get; set; }
        public virtual PaulTable PaulTable { get; set; }
        public virtual PostTable PostTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecordTable> RecordTable { get; set; }
    }
}