using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public enum BookType { [Display(Name="Art & Photography")]Art_Photography, [Display(Name = "Biographies & Memoirs")]Biographies_Memoirs, [Display(Name = "Business")] Business, [Display(Name ="Children's")] Children_s, [Display(Name = "Cookbook")] Cookbook, [Display(Name = "History")] History, [Display(Name = "Mystery & Suspense")]Mystery_Suspense, [Display(Name = "Political")] Political, [Display(Name = "Religion & Spiritual")]Religion_Spiritual, [Display(Name = "Romance")] Romance, [Display(Name = "Self-Help")]Self_Help, [Display(Name = "Sci-Fi & Fantasy")]SciFi_Fantasy, [Display(Name ="Sports & Outdorrs")]Sports_Outdoors, [Display (Name="Teen & Young Adult")]Teen_YoungAdult, [Display(Name = "Travel")] Travel }
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
               
        [Required]
        public BookType TypeOfBook { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsFiction { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsNewRelease { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsBestSeller { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}

