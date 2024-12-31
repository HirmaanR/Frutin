using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class About // /about
    {
        // comments : 
        public int CommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentUserRole { get; set; }
        public string CommentText { get; set; }
        public string CommentUserImageName { get; set; }
        // Shops : 
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopImageName { get; set; }
        public string ShopRole { get; set; }
        public IEnumerable<Link> ShopLinks { get; set; }

    }
}
