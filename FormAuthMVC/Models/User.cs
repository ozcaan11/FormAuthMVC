namespace FormAuthMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(150)]
        public string Fullname { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? IsVip { get; set; }

        public bool? IsActive { get; set; }
    }
}
