using BusinessLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult BlogList(int page=1)
        {
            var bloglist = bm.GetAll().ToPagedList(page, 6);
            return PartialView(bloglist);
        }
        public PartialViewResult FeaturedPosts()
        {
            //First Post
            var posttitle1 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 1)
                .Select(y => y.BlogTitle)
                .FirstOrDefault();
            var postimage1 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 1)
                .Select(y => y.BlogImage)
                .FirstOrDefault();
            var blogdate1 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 1)
                .Select(y => y.BlogDate)
                .FirstOrDefault();

            ViewBag.postTitle1 = posttitle1;
            ViewBag.postImage1 = postimage1;
            ViewBag.blogDate1 = blogdate1
                .ToShortDateString();
            //Second Post
            var posttitle2 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 2)
                .Select(y => y.BlogTitle)
                .FirstOrDefault();
            var postimage2 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 2)
                .Select(y => y.BlogImage)
                .FirstOrDefault();
            var blogdate2 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 2)
                .Select(y => y.BlogDate)
                .FirstOrDefault();

            ViewBag.postTitle2 = posttitle2;
            ViewBag.postImage2 = postimage2;
            ViewBag.blogDate2 = blogdate2
                .ToShortDateString();

            //third Post
            var posttitle3 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 3)
                .Select(y => y.BlogTitle)
                .FirstOrDefault();
            var postimage3 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 3)
                .Select(y => y.BlogImage)
                .FirstOrDefault();
            var blogdate3 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 3)
                .Select(y => y.BlogDate)
                .FirstOrDefault();

            ViewBag.postTitle3 = posttitle3;
            ViewBag.postImage3 = postimage3;
            ViewBag.blogDate3 = blogdate3
                .ToShortDateString();

            //fourth Post
            var posttitle4 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 4)
                .Select(y => y.BlogTitle)
                .FirstOrDefault();
            var postimage4 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 4)
                .Select(y => y.BlogImage)
                .FirstOrDefault();
            var blogdate4 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 4)
                .Select(y => y.BlogDate)
                .FirstOrDefault();

            ViewBag.postTitle4 = posttitle4;
            ViewBag.postImage4 = postimage4;
            ViewBag.blogDate4 = blogdate4
                .ToShortDateString();

                //fifth Post
            var posttitle5 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 6)
                .Select(y => y.BlogTitle)
                .FirstOrDefault();
            var postimage5 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 6)
                .Select(y => y.BlogImage)
                .FirstOrDefault();
            var blogdate5 = bm.GetAll()
                .OrderByDescending(z => z.BlogID)
                .Where(x => x.CategoryID == 6)
                .Select(y => y.BlogDate)
                .FirstOrDefault();

            ViewBag.postTitle5 = posttitle5;
            ViewBag.postImage5 = postimage5;
            ViewBag.blogDate5 = blogdate5
                .ToShortDateString();


            return PartialView();
        }
        public PartialViewResult OtherFeaturedPosts()
        {
            return PartialView();
        }
        public PartialViewResult MailSubscribe()
        {
            return PartialView();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }
        public PartialViewResult BlogCover()
        {
            return PartialView();
        }
        public PartialViewResult BlogReadAll()
        {
            return PartialView();
        }
        public ActionResult BlogByCategory()
        {
            return View();
        }

    }
}