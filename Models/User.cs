namespace ContactBook.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {

        public class DateTimeRangeAtt : RangeAttribute
        {
            public DateTimeRangeAtt()
              : base(typeof(DateTime),
                     new DateTime(1900, 1, 1).ToShortDateString(),
                     new DateTime(DateTime.Now.Year - 15, 1, 1).ToShortDateString())
            { }
        }

        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        [RegularExpression(@"(^[a-zA-Z][a-zA-Z\\s]+$)", ErrorMessage = "The First Name is not entered in a correct format")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        [RegularExpression(@"(^[a-zA-Z][a-zA-Z\\s]+$)", ErrorMessage = "The Last Name is not entered in a correct format")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        [EmailAddress]
        public string Email { get; set; }

        [DateTimeRangeAtt(ErrorMessage = "Date must be before 2005/01/01")]
        public DateTime? DateOfBirth { get; set; }
        //public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        //[StringLength(16, MinimumLength = 8, ErrorMessage = "Password needs to be between 8 and 16 characters")]
       // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "The  password is not entered in a correct format. Password needs, atleast one number, one lowercase, one upercase and one special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsEmailVerified { get; set; }

        public System.Guid ActivationCode { get; set; }

        public string ResetPassword { get; set; }

    }

}