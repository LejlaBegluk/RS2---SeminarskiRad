using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsPortal.Model.Request
{
    public class UserUpsertRequest
        {
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            [Required]
            public string Username { get; set; }
            public string Password { get; set; }
            public string PasswordConfirmation { get; set; }
            public byte[] Photo { get; set; }
            public byte[] PhotoThumb { get; set; }
            public string FullName { get; set; }
            public int Role { get; set; }
            public DateTime BirthDate { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreateOn { get; set; }
    }
    }
