namespace SiteCoreTestApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        [StringLength(20)]
        public string UserPassword { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        public bool? Active { get; set; }

        public DateTime? UserCreatedOn { get; set; }

        [StringLength(20)]
        public string UserCreatedBy { get; set; }

        public DateTime? UserUpdatedOn { get; set; }

        [StringLength(20)]
        public string UserUpdatedBy { get; set; }
    }
}
