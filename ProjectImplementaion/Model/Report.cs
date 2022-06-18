namespace ProjectImplementaion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
    {
        public int Id { get; set; }

        public int PerformerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int HoursNumber { get; set; }

        [Required]
        [StringLength(250)]
        public string Action { get; set; }

        public bool Check { get; set; }

        public virtual Performer Performer { get; set; }
    }
}
