using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager();
        public ActionResult Index()
        {
            var AboutContent = abm.GetAll();
            return View(AboutContent);
        }
        public PartialViewResult Footer()
        {
            var aboutcontentlist = abm.GetAll();
            return PartialView(aboutcontentlist);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autman = new AuthorManager();
            var authorlist= autman.GetAll();
            return PartialView(authorlist);
        }
    }
}