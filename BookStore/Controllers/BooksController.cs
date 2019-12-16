using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.DatabaseContext;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private BookStoreDbContext db = new BookStoreDbContext();

        // GET: Books
        public ActionResult Index()
        {
            List<Book> books = db.Books.OrderBy(x => x.Name).ToList();
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult AddToCart(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var shoppingCart = db.ShoppingCarts.OrderByDescending(x => x.DateCreated).FirstOrDefault();
            if (shoppingCart == null)
            {
                shoppingCart = db.ShoppingCarts.Add(new ShoppingCart());
            }

            shoppingCart.AddToCart(book);
            db.SaveChanges();

            //return RedirectToAction("Index", "ShoppingCarts");
            return RedirectToAction("Details", "ShoppingCarts", new { id = shoppingCart.Id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
