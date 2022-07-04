using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
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
        public PartialViewResult BlogList(int page = 1)
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
        public ActionResult BlogDetails()
        {
            return View();
        }
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id)
                .Select(y => y.Category.CategoryName)
                .FirstOrDefault();
            var CategoryDesc = bm.GetBlogByCategory(id)
                .Select(y => y.Category.CategoryDescription)
                .FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            ViewBag.CategoryDesc = CategoryDesc;
            return View(BlogListByCategory);
        }
        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values = values;
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBL(b);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList");
        }
     
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values = values;
            ViewBag.values2 = values2;
            Blog blog = bm.FindBlog(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentlist = cm.CommentByBlog(id);
            return View(commentlist);
        }
    }
}