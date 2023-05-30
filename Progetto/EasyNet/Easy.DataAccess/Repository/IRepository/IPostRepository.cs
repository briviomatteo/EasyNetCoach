using EasyNet.DataAccess.Repository.IRepository;
using EasyNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.DataAccess.Repository.IRepository
{
    public interface IPostRepository:IRepository<Post>
    {
        void Update(Post post);
    }
}
