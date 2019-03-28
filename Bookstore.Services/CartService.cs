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

                entity.Quantity = model.Quantity;
                entity.ItemTotal = model.Price * Convert.ToDecimal(model.Quantity);
                return ctx.SaveChanges() == 1;
            }
        }



        public bool DeleteFromCart(int cartId)
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

        public BookDescription GetBookDescription(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Book
                    .Single(e => e.BookId == bookId);
                return new BookDescription
                {
                    BookId = entity.BookId,
                    TypeOfBook = entity.TypeOfBook,
                    Title = entity.Title,
                    Author = entity.Author,
                    IsFiction = entity.IsFiction,
                    IsBestSeller = entity.IsBestSeller,
                    IsNewRelease = entity.IsNewRelease,
                    Price = entity.Price,
                    BookTypeAsString = Helper.GetDisplayName(entity.TypeOfBook),
                    Description = entity.Description,

                };
            }
        }
        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    using (ApplicationDbContext usersShoppingCart = new ApplicationDbContext())
        //    {
        //        string cartStr = string.Format("Cart ({0})", usersShoppingCart.GetCount());
        //        cartCount.InnerText = cartStr;
    }
}
        //public ActionResult UpdateInventory(int cartId, int bookId, int quantity)
        //{

        //    List<UserCartListItem> userCart = GetUserBooks();
        //    foreach (var book in userCart)
        //    {
        //        for (int i = 0; i < quantity; i++)
        //        {
        //            if (bookId ==
        //        }
        //    }

        //    return View();
        //}

        //public bool ClearCart()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Cart
        //            .Where(e => e.OwnerId == _userId)
        //            .ToList();

        //        var x = query.Count;
        //        var i = x;
        //        while(i!=0)
        //        {
        //            foreach(var q in query)
        //            {
        //                (ctx.Cart.Remove(q i));
        //                i--;
        //            }
        //            return ctx.SaveChanges() == x;
  
        
    


