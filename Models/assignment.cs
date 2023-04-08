namespace QuanLyDuAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("assignment")]
    public partial class assignment
    {
        [Key]
        public int assignment_id { get; set; }

        public int? task_id { get; set; }

        public int? user_id { get; set; }

        public virtual task task { get; set; }

        public virtual users users { get; set; }
    }
}
