using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstChallenge.Models;

namespace FirstChallenge.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var comicBooks = ComicBookManager.GetComicBooks();
            return View(comicBooks);
        }
        
        /*
        public ActionResult Comic41()
        {
            var comicBooks = ComicBookManager.GetComicBooks();
            return View(comicBooks);
        }

        public ActionResult Comic13()
        {
            var comicBooks = ComicBookManager.GetComicBooks();
            return View(comicBooks.ElementAt(1));
        }

        public ActionResult Comic17()
        {
            var comicBooks = ComicBookManager.GetComicBooks();
            return View(comicBooks.ElementAt(2));
        }
        */

        public ActionResult Detail(int id)
        {
            var comics = ComicBookManager.GetComicBooks();
            var comic = comics.FirstOrDefault(p => p.ComicBookId == id);
            return View(comic);
        }
    }
}