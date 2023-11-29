namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActivityLog")]
    public partial class ActivityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LogID { get; set; }

        public int? UserID { get; set; }

        public string Action { get; set; }

        public DateTime? DateTime { get; set; }

        public virtual Users Users { get; set; }
    }
}
