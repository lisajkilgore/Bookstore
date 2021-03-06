﻿using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{

    public class BookCreate
    {
        [Required]
        [DisplayName("Book ID")]
        public int BookId { get; set; }

        [DisplayName("Category")]
        public BookType TypeOfBook { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        [DisplayName("Fiction")]
        public bool IsFiction { get; set; }

        [DisplayName("New Release")]
        public bool IsNewRelease { get; set; }

        [DisplayName("Best Seller")]
        public bool IsBestSeller { get; set; }

        public decimal Price { get; set; }

        public int Inventory { get; set; }

        public string Description { get; set; }


    }
}
