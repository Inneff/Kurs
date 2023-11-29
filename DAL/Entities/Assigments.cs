namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Assigments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssigmentID { get; set; }

        public int? UserID { get; set; }

        public int? ProjectID { get; set; }

        public int? TaskID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public virtual Projects Projects { get; set; }

        public virtual Tasks Tasks { get; set; }

        public virtual Users Users { get; set; }
    }
}
