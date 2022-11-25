using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsPortal.WebAPI.Model
{

    public class MUser 
    {
        public int Id { get; set; }
     //   public byte[] Image { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        [System.ComponentModel.Browsable(false)]
        public DateTime CreatedOn { get; set; }
        [System.ComponentModel.Browsable(false)]
        public bool IsActive { get; set; }
        //  public int? EditorId { get; set; }
        // public MUser Editor { get; set; }
        public string Active { get; set; }
        public string Uloga { get; set; }
        public byte[] Photo { get; set; }
        public int RoleId { get; set; }
        public MRole Role { get; set; }
    }
}
