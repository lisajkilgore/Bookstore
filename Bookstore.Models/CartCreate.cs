using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class CartCreate
    {
        [Required]
        public int CartId { get; set; }
        public int BookId { get; set; }
        public Guid OwnerId { get; set; }
        public int Quantity { get; set; }
        public virtual Book Book { get; set; }


        [MaxLength(8000)]
        public string Content { get; set; }

    }
}


