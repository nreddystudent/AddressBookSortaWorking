namespace ContactBook.Models
{

    using System;
    using System.Collections.Generic;

    public partial class User
    {

        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Nullable<System.DateTime> DateOfBirth { get; set; }

        public string Password { get; set; }

        public bool IsEmailVerified { get; set; }

        public System.Guid ActivationCode { get; set; }

        public string ResetPassword { get; set; }

    }

}