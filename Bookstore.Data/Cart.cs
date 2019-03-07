using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public Guid OwnerId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price{ get; set; }

        [Required]
        [DisplayName("Total Cost")]
        public decimal CartTotal { get; set; }

        [Required]
        public virtual Book Book { get; set; }
    }
}
