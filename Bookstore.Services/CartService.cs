using Bookstore.Data;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Services
{
    public class CartService
    {
        private readonly Guid _userId;

        public CartService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCart(CartCreate model)
        {
            var entity =
                new Cart()
                {
                    OwnerId = _userId,
                    CartId = model.CartId,
                    BookId = model.BookId,
                    Quantity = model.Quantity,
                    Book = model.Book,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cart.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserCartListItem> GetUserBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cart
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new UserCartListItem
                        {
                            CartId = e.CartId,
                            OwnerId = e.OwnerId,
                            BookId = e.BookId,
                            Quantity = e.Quantity,
                            Book = e.Book,

                        }
                        );
                return query.ToArray();
            }
        }

        public CartDetail GetCartById(int cartId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cart
                    .Single(e => e.CartId == cartId && e.OwnerId == _userId);
                return
                    new CartDetail
                    {
                        CartId = entity.CartId,
                        OwnerId = entity.OwnerId,
                        BookId = entity.BookId,
                        Quantity = entity.Quantity,
                        Book = entity.Book
                    };

            }
        }

        public bool UpdateCart(CartEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cart
                    .Single(e => e.CartId == model.CartId && e.OwnerId == _userId);

                entity.CartId = model.CartId;
                entity.OwnerId = model.OwnerId;
                entity.BookId = model.BookId;
                entity.Quantity = model.Quantity;
                entity.Book = model.Book;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCart(int cartId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cart
                    .Single(e => e.CartId == cartId && e.OwnerId == _userId);

                ctx.Cart.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
