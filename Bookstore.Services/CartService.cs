﻿using Bookstore.Data;
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

        public IEnumerable<UserBookListItem> GetUserBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cart
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new UserBookListItem
                        {
                            CartId = e.CartId,
                            BookId = e.BookId,
                            Quantity = e.Quantity,
                            Book = e.Book,

                        }
                        );
                return query.ToArray();
            }
        }
    }
}