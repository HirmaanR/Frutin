using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitGenericRepository : IDisposable
    {
        FrutinContext db = new FrutinContext();

        private GenericRepository<Tag> _tagRepository; // Tag
        public GenericRepository<Tag> TagRepository
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new GenericRepository<Tag>(db);
                return _tagRepository;
            }
        }


        private GenericRepository<Order> _orderRepository; // Order 
        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new GenericRepository<Order>(db);
                return _orderRepository;
            }
        }


        private GenericRepository<OrderProduct> _orderProductRepository; // Order repository
        public GenericRepository<OrderProduct> ShopCartRepository
        {
            get
            {
                if (_orderProductRepository == null)
                    _orderProductRepository = new GenericRepository<OrderProduct>(db);
                return _orderProductRepository;
            }
        }


        private GenericRepository<Role> _roleRepository; // role
        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new GenericRepository<Role>(db);
                return _roleRepository;
            }
        }



        private GenericRepository<ProductTag> _productTagRepository; // ProductTag
        public GenericRepository<ProductTag> ProductTagRepository
        {
            get
            {
                if (_productTagRepository == null)
                    _productTagRepository = new GenericRepository<ProductTag>(db);
                return _productTagRepository;
            }
        }




        private GenericRepository<Link> _linkRepository; // Link
        public GenericRepository<Link> LinkRepository
        {
            get
            {
                if (_linkRepository == null)
                    _linkRepository = new GenericRepository<Link>(db);
                return _linkRepository;
            }
        }


        private GenericRepository<Comment> _commentRepository; // Comment
        public GenericRepository<Comment> CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new GenericRepository<Comment>(db);
                return _commentRepository;
            }
        }



        private GenericRepository<Category> _categoryRepository; // Category
        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new GenericRepository<Category>(db);
                return _categoryRepository;
            }
        }


        private GenericRepository<BlogTag> _blogTagRepository; // BlogTag
        public GenericRepository<BlogTag> BlogTagRepository
        {
            get
            {
                if (_blogTagRepository == null)
                    _blogTagRepository = new GenericRepository<BlogTag>(db);
                return _blogTagRepository;
            }
        }

        private GenericRepository<Blog> _blogRepository; // blog
        public GenericRepository<Blog> BlogRepository
        {
            get
            {
                if (_blogRepository == null)
                    _blogRepository = new GenericRepository<Blog>(db);
                return _blogRepository;
            }
        }



        private GenericRepository<Product> _productRepository; // product
        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new GenericRepository<Product>(db);
                return _productRepository;
            }
        }

        private GenericRepository<Shop> _shopRepository; // Shop
        public GenericRepository<Shop> ShopRepository
        {
            get
            {
                if (_shopRepository == null)
                    _shopRepository = new GenericRepository<Shop>(db);
                return _shopRepository;
            }
        }

        private GenericRepository<User> _userRepository; // user 
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new GenericRepository<User>(db);
                return _userRepository;
            }
        }

        // header models repository : 
        private GenericRepository<HeaderMenu> _headerMenuRepository; // menu 
        public GenericRepository<HeaderMenu> HeaderMenuRepository
        {
            get
            {
                if (_headerMenuRepository == null)
                    _headerMenuRepository = new GenericRepository<HeaderMenu>(db);
                return _headerMenuRepository;
            }
        }

        private GenericRepository<ChildHeaderMenu> _headerChildMenuRepository; // child menu  
        public GenericRepository<ChildHeaderMenu> HeaderChildMenuRepository
        {
            get
            {
                if (_headerChildMenuRepository == null)
                    _headerChildMenuRepository = new GenericRepository<ChildHeaderMenu>(db);
                return _headerChildMenuRepository;
            }
        }

        private GenericRepository<HeaderNotification> _headerNotificationRepository; // notification 
        public GenericRepository<HeaderNotification> HeaderNotificationRepository
        {
            get
            {
                if (_headerNotificationRepository == null)
                    _headerNotificationRepository = new GenericRepository<HeaderNotification>(db);
                return _headerNotificationRepository;
            }
        }

        // end header models repository


        public void Dispose()
        {
            db.Dispose();

        }
        public void SaveChange()
        {
            db.SaveChanges();
        }
    }
}
