using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.DataAccess.Repository.IRepository;
using EasyNet.Data;
using EasyNet.DataAccess.Repository;
using EasyNet.Models;

namespace EasyNet.DataAccess.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly AppDbContext _db;
        public PostRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Post post)
        {
            _db.Posts.Update(post);
        }



    }
}