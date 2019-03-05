﻿using Bookstore.Data;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Title = model.Title,
                    Author = model.Author,
                    IsFiction = model.IsFiction,
                    IsNewRelease = model.IsNewRelease,
                    IsBestSeller = model.IsBestSeller,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    TypeOfBook = model.TypeOfBook

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
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>

                    new AdminBookListItem
                    {
                        Title = e.Title,
                        Author = e.Author,
                        IsFiction = e.IsFiction,
                        IsNewRelease = e.IsNewRelease,
                        IsBestSeller = e.IsBestSeller,
                        Price = e.Price,
                        Quantity = e.Quantity,
                        TypeOfBook = e.TypeOfBook
                    }


                    );

                return query.ToArray();
            }
        }
    }
}


