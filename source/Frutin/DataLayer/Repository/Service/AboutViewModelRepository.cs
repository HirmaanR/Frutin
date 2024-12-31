using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AboutViewModelRepository : IAboutViewModelRepository
    {
        FrutinContext db;
        public AboutViewModelRepository(FrutinContext context)
        {
            this.db = context;
        }
        
        public IEnumerable<About> GetAll()
        {
            var shops = db.Shop.Select(s => new About
            {
                ShopID = s.ShopID,
                ShopName = s.Name,
                ShopImageName = s.ImageName,
                ShopRole = s.Role.Tittle,
                ShopLinks = s.Links.ToList()
            }).ToList();

            var comments = db.Comment.Where(c => c.IsAboutComment).Select(c => new About
            {
                CommentID = c.CommentID,
                CommentUserName = c.User.FirstName + " " + c.User.LastName,
                CommentUserRole = (c.User.IsSeller == true ? "قروشنده" : "مشتری ما"),
                CommentText = c.Text,
                CommentUserImageName = c.User.ImageName
            }).ToList();

            List<About> abouts = new List<About>();
            abouts.AddRange(shops);
            abouts.AddRange(comments);

            return abouts;
        }
        
    }   
}
