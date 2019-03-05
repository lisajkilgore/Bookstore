using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class UserBookListItem
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public Guid OwnerId { get; set; }
        public int Quantity { get; set; }
        public virtual Book Book { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
