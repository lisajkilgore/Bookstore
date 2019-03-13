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
                        new Models.UserCartListItem
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
                entity.Quantity = model.Quantity;
                entity.Price = model.Price;
                entity.ItemTotal = model.ItemTotal;

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

        // public ActionResult AddToCart(int bookId)
        //{
        //    CartCreate cartCreate = new CartCreate();

        //    var svc = CreateCartService();

        //    svc.AddToCart(bookId);
        //    if (Session["cart"] == null)
        //    {
        //        List<UserCartListItem> cart = new List<UserCartListItem>();
        //        cart.Add(new UserCartListItem { CartId = cartCreate.BookId, Quantity = 1 });
        //        Session["cart"] = cart;
        //    }
        //    else
        //    {
        //        List<UserCartListItem> cart = (List<UserCartListItem>)Session["cart"];
        //        int index = isExist(bookId);
        //        if (index != -1)
        //        {
        //            cart[index].Quantity++;
        //        }
        //        else
        //        {
        //            cart.Add(new UserCartListItem { CartId = cartCreate.BookId, Quantity = 1 });
        //        }
        //        Session["cart"] = cart;
        //    }
        //    return RedirectToAction("Cart");
        //}
        //private int isExist(int bookId)
        //{
        //    List<UserCartListItem> cart = (List<UserCartListItem>)Session["cart"];
        //    for (int i = 0; i < cart.Count; i++)
        //        if (cart[i].CartId.Equals(bookId))
        //            return i;
        //    return -1;
        //}

        public bool AddToCart(BookDetail book)
        {
            CartCreate cartCreate = new CartCreate()
            {
                BookId = book.BookId,
                Price = book.Price,
                Quantity = 1,
                ItemTotal = 1,
                OwnerId = _userId
            };

            return CreateCart(cartCreate);
        }
    }
}
 

