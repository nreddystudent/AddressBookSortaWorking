using System.Configuration;

namespace ContactBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        public int ContactID { get; set; }

     
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        [Column("First Name")]
        [Display(Name="First Name")]

        public string FirstName { get; set; }

        [StringLength(50)]
        [Column("Last Name")]
        public string LastName { get; set; }

        [Phone]
        [StringLength(10)]

        [Column("Phone Number")]
        public string CellNumber { get; set; }
     
        [EmailAddress]
        [StringLength(254)]
        public string Email { get; set; }

        [StringLength(254)]
        public string Address { get; set; }

        public int? UserID { get; set; }
        public bool Favourite { get; set; }
        public int CategoryId { get; set; }

    }
}