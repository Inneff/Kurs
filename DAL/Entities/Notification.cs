namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NotificationID { get; set; }

        public int? UserID { get; set; }

        public int? ProjectID { get; set; }

        public int? TaskID { get; set; }

        public string Text { get; set; }

        public DateTime? DateTime { get; set; }

        public virtual Projects Projects { get; set; }

        public virtual Tasks Tasks { get; set; }

        public virtual Users Users { get; set; }
    }
}
