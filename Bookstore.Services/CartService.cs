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
            using (var ctx = new ApplicationDbContext())
            {

                var cart = new Cart()
                {
                    OwnerId = _userId,
                    CartId = model.CartId,
                    BookId = model.BookId,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    ItemTotal = model.ItemTotal
                };
                cart.ItemTotal = cart.Price * Convert.ToDecimal(model.Quantity);
                ctx.Cart.Add(cart);
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
                            Title = e.Book.Title,
                            Quantity = e.Quantity,
                            Price = e.Price,
                            ItemTotal = e.ItemTotal,
                        }
                        );
                return query.ToArray();
            }
        }

        public CartTotalModel GetUserCart()
        {
            var userBooks = GetUserBooks();
            var cartTotal = 0m;
            foreach (var book in userBooks)
            {
                cartTotal += book.ItemTotal;
            }

            return new CartTotalModel()
            {
                CartTotal = cartTotal,
                CartItems = userBooks,
            };
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
                        Title = entity.Book.Title,
                        Quantity = entity.Quantity,
                        Price = entity.Price,
                        ItemTotal = entity.ItemTotal,
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
                entity.Book.Title = model.Title;
                entity.Quantity = model.Quantity;
                entity.Price = model.Price;



                model.ItemTotal = model.Price * Convert.ToDecimal(model.Quantity);
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

        public bool AddToCart(BookDetail book)
        {
            CartCreate cartCreate = new CartCreate()
            {
                BookId = book.BookId,
                Title = book.Title,
                Price = book.Price,
                Quantity = 1,
                ItemTotal = 1,
                OwnerId = _userId
            };

            return CreateCart(cartCreate);
        }
    }
}


