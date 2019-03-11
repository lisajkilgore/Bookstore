using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class CartTable
    {
        public decimal CartTotal { get; set; }
        public IEnumerable<UserCartListItem> CartItems { get; set; }
    }
}
