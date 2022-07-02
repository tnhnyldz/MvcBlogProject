using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogManager = new BlogManager();
        AuthorManager authormanager = new AuthorManager();
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogManager.GetBlogByID(id);
            return PartialView(authordetail);
        }
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogAuthorid = blogManager.GetAll()
                .Where(x => x.BlogID == id)
                .Select(y => y.AuthorID)
                .FirstOrDefault();
            var authorblogs = blogManager.GetBlogByAuthor(blogAuthorid);
            return PartialView(authorblogs);
        }
        public ActionResult AuthorList()
        {
            var authorlist = authormanager.GetAll();
            return View(authorlist);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            authormanager.AddAuthorBL(p);
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author Auth = authormanager.FindAuthor(id);
            return View(Auth);
        
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            authormanager.EditAuthor(p);
            return RedirectToAction("AuthorList");
        }


    }
}