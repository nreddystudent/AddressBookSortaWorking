using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class ResetPasswordValidation
    {
        [Required(ErrorMessage = "New Password required", AllowEmptyStrings = false)]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password needs to be between 8 and 16 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "The  password is not entered in a correct format. Password needs, atleast one number, one lowercase, one upercase and one special character")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password needs to be between 8 and 16 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "The  password is not entered in a correct format. Password needs, atleast one number, one lowercase, one upercase and one special character")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ResetCode { get; set; }
    }
}