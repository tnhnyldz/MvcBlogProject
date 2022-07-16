using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        AuthorManager authormanager = new AuthorManager(new EfAuthorDal());
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogManager.GetBlogByID(id);
            return PartialView(authordetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogAuthorid = blogManager.GetList()
                .Where(x => x.BlogID == id)
                .Select(y => y.AuthorID)
                .FirstOrDefault();
            var authorblogs = blogManager.GetBlogByAuthor(blogAuthorid);
            return PartialView(authorblogs);
        }
        public ActionResult AuthorList()
        {
            var authorlist = authormanager.GetList();
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
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult results = authorValidator.Validate(p);
            if (results.IsValid)
            {
                authormanager.AuthorAdd(p);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author Auth = authormanager.GetByID(id);
            return View(Auth);
        
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult results = authorValidator.Validate(p);
            if (results.IsValid)
            {
                authormanager.AuthorUpdate(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}