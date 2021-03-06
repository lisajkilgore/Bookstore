﻿using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class CartEdit
    {
        public int CartId { get; set; }
        public Guid OwnerId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Item Total")]
        public decimal ItemTotal { get; set; }

        public virtual Book Book { get; set; }
    }
}
