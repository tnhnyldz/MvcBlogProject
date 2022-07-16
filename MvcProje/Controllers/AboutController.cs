using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var AboutContent = abm.GetList();
            return View(AboutContent);
        }
        public PartialViewResult Footer()
        {
            var aboutcontentlist = abm.GetList();
            return PartialView(aboutcontentlist);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autman = new AuthorManager(new EfAuthorDal());
            var authorlist = autman.GetList();
            return PartialView(authorlist);
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutList = abm.GetList();
            return View(aboutList);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.AboutUpdate(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}