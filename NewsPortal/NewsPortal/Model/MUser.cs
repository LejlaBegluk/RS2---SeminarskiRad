using System;
using System.Collections.Generic;

namespace NewsPortal.WebAPI.Model
{

    public class MUser 
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public int? EditorId { get; set; }
        public MUser Editor { get; set; }

        public ICollection<MUserRole> UserRoles { get; set; }


    }
}
