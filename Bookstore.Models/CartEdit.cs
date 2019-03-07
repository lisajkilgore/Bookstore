using Bookstore.Data;
using System;
using System.Collections.Generic;
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
        public int Quantity { get; set; }
        public virtual Book Book { get; set; }
        
    }
}
