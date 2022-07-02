using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {

        Repository<Author> repoAut = new Repository<Author>();
        public List<Author> GetAll()
        {
            return repoAut.List();
        }
        public int AddAuthorBL(Author p)
        {
            if (p.AuthorName == "" || p.AuthorTitle == "")
            {
                return -1;
            }
            return repoAut.Insert(p);
        }
        //return author by ıd
        public Author FindAuthor(int id)
        {
            return repoAut.Find(x => x.AuthorID == id);
        }
        public int EditAuthor(Author p)
        {
            Author author = repoAut.Find(x => x.AuthorID == p.AuthorID);
            author.AboutShort = p.AuthorAbout;
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            return repoAut.Update(author);
        }
    }
}
