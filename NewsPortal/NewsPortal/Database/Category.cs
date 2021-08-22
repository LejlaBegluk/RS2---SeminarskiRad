﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsPortal.WebAPI.Database
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
