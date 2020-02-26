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
        [Display(Name = "First Name")]
        [RegularExpression(@"(^[a-zA-Z][a-zA-Z\\s]+$)", ErrorMessage = "The First Name is not entered in a correct format")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Column("Last Name")]
        [RegularExpression(@"(^[a-zA-Z][a-zA-Z\\s]+$)", ErrorMessage = "The Last Name is not entered in a correct format")]
        public string LastName { get; set; }

        [Display(Name = "Phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number consist of 10 digits")]
        [RegularExpression(@"(^[0-9]+$)", ErrorMessage = "Phone number consist of 10 digits")]
        [Phone]
        [Column("Phone Number")]
        public string CellNumber { get; set; }

        [EmailAddress]
        [StringLength(254)]
        [RegularExpression(@"(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        public int UserID { get; set; }
        public bool Favourite { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
    }
}