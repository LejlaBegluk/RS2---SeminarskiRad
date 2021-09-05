using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.WebAPI.Model
{
    public class MUserRole 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreateDate { get; set; }
        public MUser User { get; set; }
        public MRole Role { get; set; }
    }
}
