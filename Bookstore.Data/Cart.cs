using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public class Cart
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int OwnerId { get; set; }
        public int Quantity { get; set; }

        public virtual Book Book { get; set; }
    }
}
