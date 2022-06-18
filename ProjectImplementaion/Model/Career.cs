namespace ProjectImplementaion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Career")]
    public partial class Career
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int PositionId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateEnd { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Position Position { get; set; }
    }
}
