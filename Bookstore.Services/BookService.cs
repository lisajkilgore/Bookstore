using Bookstore.Data;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Bookstore.Services
{
    public class BookService
    {
        private readonly Guid _userId;

        public BookService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    OwnerId = _userId,
                    BookId = model.BookId,
                    TypeOfBook = model.TypeOfBook,
                    Title = model.Title,
                    Author = model.Author,
                    IsFiction = model.IsFiction,
                    IsNewRelease = model.IsNewRelease,
                    IsBestSeller = model.IsBestSeller,
                    Price = model.Price,
                    Inventory = model.Inventory,
                    Description = model.Description,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Book.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AdminBookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Book                    
                    .Select(
                        e =>

                    new AdminBookListItem
                    {
                        BookId = e.BookId,
                        TypeOfBook = e.TypeOfBook,
                        Title = e.Title,
                        Author = e.Author,
                        IsFiction = e.IsFiction,
                        IsNewRelease = e.IsNewRelease,
                        IsBestSeller = e.IsBestSeller,
                        Price = e.Price,
                        Inventory = e.Inventory,
                        Description = e.Description.Substring(0, 50),
                    }


                    );
                var array = query.ToArray();
                foreach (var book in array)
                {
                    book.BookTypeString = Helper.GetDisplayName(book.TypeOfBook);
                }
                return array;
            }
        }

        public BookDetail GetBookById(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .Book
                .Single(e => e.BookId == bookId);
                
                    return new BookDetail
                    {
                        BookId = entity.BookId,
                        TypeOfBook = entity.TypeOfBook,
                        Title = entity.Title,
                        Author = entity.Author,
                        IsFiction = entity.IsFiction,
                        IsNewRelease = entity.IsNewRelease,
                        IsBestSeller = entity.IsBestSeller,
                        Price = entity.Price,
                        Inventory = entity.Inventory,
                        BookTypeAsString = Helper.GetDisplayName(entity.TypeOfBook),
                        Description = entity.Description,
                    };
            }
        }



                public bool UpdateBook(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Book
                    .Single(e => e.BookId == model.BookId);
                entity.BookId = model.BookId;
                entity.TypeOfBook = model.TypeOfBook;
                entity.Title = model.Title;
                entity.Author = model.Author;
                entity.IsFiction = model.IsFiction;
                entity.IsNewRelease = model.IsNewRelease;
                entity.IsBestSeller = model.IsBestSeller;
                entity.Price = model.Price;
                entity.Inventory = model.Inventory;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Book
                    .Single(e => e.BookId == bookId && e.OwnerId == _userId);

                ctx.Book.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
    static class Helper
    {
        public static string GetDisplayName(this Enum bookType)
        {
            if (bookType.ToString().Contains('_'))
                return bookType
                    .GetType()
                    .GetMember(bookType.ToString())
                    .First()
                    .GetCustomAttribute<DisplayAttribute>()
                    .GetName();
            else
                return bookType.ToString();
        }
    }
}





