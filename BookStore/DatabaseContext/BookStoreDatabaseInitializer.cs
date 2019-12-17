using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BookStore.DatabaseContext
{
    public class BookStoreDatabaseInitializer : DropCreateDatabaseIfModelChanges<BookStoreDbContext>
    {
        protected override void Seed(BookStoreDbContext context)
        {
            context.Books.AddOrUpdate(
                x => x.Name,
                new Book
                {
                    Name = "Interesting",
                    Author = "James Strand",
                    Description = "Interesting ways of living life.",
                    Year = 1999,
                    Price = 4
                },
                new Book
                {
                    Name = "Confusion",
                    Author = "James Strand",
                    Description = "The day that left James confused.",
                    Year = 2000,
                    Price = 7
                },
                new Book
                {
                    Name = "Famous",
                    Author = "Anna Leut",
                    Description = "How Anna Leur became famous.",
                    Year = 1997,
                    Price = 12
                },
                new Book
                {
                    Name = "Best Friend",
                    Author = "Susanna Darn",
                    Description = "How Susanna met her best friend.",
                    Year = 2010,
                    Price = 10
                },
                new Book
                {
                    Name = "Lost",
                    Author = "Arthur Red",
                    Description = "The day that Arthur Red got lost.",
                    Year = 2018,
                    Price = 15
                },
                new Book
                {
                    Name = "Hello Friend",
                    Author = "Arthur Red",
                    Description = "Truth about the society.",
                    Year = 2019,
                    Price = 20
                },
                new Book
                {
                    Name = "In Control",
                    Author = "Mason Sam",
                    Description = "How Mason gained control over everything",
                    Year = 2017,
                    Price = 25
                }
                );
        }
    }
}