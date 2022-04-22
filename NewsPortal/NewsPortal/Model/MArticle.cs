using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Model
{
    public class MArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [System.ComponentModel.Browsable(false)]
        public string Content { get; set; }
        public int Likes { get; set; }
        public byte[] Photo { get; set; }
        public byte[] PhotoThumb { get; set; }
        public DateTime CreateOn { get; set; }
        [System.ComponentModel.Browsable(false)]
        public DateTime? UpdatedOn { get; set; }
        public bool Active { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int UserId { get; set; }
        [System.ComponentModel.Browsable(false)]
        //public User User { get; set; }
        //[System.ComponentModel.Browsable(false)]
        public int CategoryId { get; set; }
        //[System.ComponentModel.Browsable(false)]
        //public Category Category { get; set; }
        //[System.ComponentModel.Browsable(false)]
        //public virtual ICollection<MComment> Comments { get; set; }
        public string ActiveStatus { get; set; }
        public string CategoryName { get; set; }


    }
}
