using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public enum BookType { Art_Photography, Biographies_Memoirs, Business, Children_s, Cookbook, History, Mystery_Suspense, Political, Religion_Spiritual, Romance, Self_Help, SciFi_Fantasy, Sports_Outdoors, Teen_YoungAdult, Travel}
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }



        [DefaultValue(true)]
        public bool IsFiction { get; set; }

        [DefaultValue(false)]
        public bool IsNewRelease { get; set; }

        [DefaultValue(false)]
        public bool IsBestSeller { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public BookType TypeOfBook { get; set; }
    }
}
