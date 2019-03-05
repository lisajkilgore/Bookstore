using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public enum BookType { Art_Photography, Biographies_Memoirs, Business, Children_s, Cookbook, History, Mystery_Suspense, Political, Religion_Spiritual, Romance, Self_Help, SciFi_Fantasy, Sports_Outdoors, Teen_YoungAdult, Travel }

    public class AdminBookListItem
    {
        public int BookId { get; set; }
        public Guid OwnerId { get; set; }
        public bool IsFiction { get; set; }
        public bool IsNewRelease { get; set; }
        public bool IsBestSeller { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookType TypeOfBook { get; set; }

    }
}
