namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Files
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FileID { get; set; }

        public int? ProjectID { get; set; }

        public int? TaskID { get; set; }

        [StringLength(50)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string FilePath { get; set; }

        public int? FileSize { get; set; }

        public virtual Projects Projects { get; set; }

        public virtual Tasks Tasks { get; set; }
    }
}
