using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class BookDetail
    {
        public int BookId { get; set; }
        public BookType TypeOfBook { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsFiction { get; set; }
        public bool IsNewRelease { get; set; }
        public bool IsBestSeller { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString() => $"[{BookId}] {Title}";
    }
}
