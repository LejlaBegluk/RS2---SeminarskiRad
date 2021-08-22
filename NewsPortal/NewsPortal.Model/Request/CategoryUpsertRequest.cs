using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsPortal.Model.Request
{
        public class CategoryUpsertRequest
        {
            [Required]
            public string Name { get; set; }
        }
    }