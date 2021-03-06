﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int BookId { get; set; }
        
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price{ get; set; }

        [Required]
        public decimal ItemTotal { get; set; }

        
        public virtual Book Book { get; set; }
    }
}
