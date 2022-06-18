namespace ProjectImplementaion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Performer")]
    public partial class Performer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Performer()
        {
            Reports = new ObservableListSource<Report>();
        }

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int ProjectId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableListSource<Report> Reports { get; set; }

        public override string ToString()
        {
            return Employee.ToString();
        }
    }
}
