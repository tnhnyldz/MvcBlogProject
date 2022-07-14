using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repocategory = new Repository<Category>();
        public List<Category> GetAll()
        {
            return repocategory.List();
        }
        public int CategoryAddBL(Category p)
        {
            return repocategory.Insert(p);
        }
        public Category FindCategory(int id)
        {
            return repocategory.Find(x => x.CategoryID == id);
        }
        public int EditCategory(Category p)
        {
            Category category = repocategory.Find(x => x.CategoryID == p.CategoryID);
            category.CategoryName = p.CategoryName;
            category.CategoryDescription = p.CategoryDescription;
            return repocategory.Update(category);
        }
        public int CategoryStatusFalseBL(int id)
        {
            Category category = repocategory.Find(x => x.CategoryID == id);
            category.CategoryStatus = false;
            return repocategory.Update(category);
        }
        public int CategoryStatusTrueBL(int id)
        {
            Category category = repocategory.Find(x => x.CategoryID == id);
            category.CategoryStatus = true;
            return repocategory.Update(category);
        }
    }
}
