using Easy.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNet.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPostRepository Post { get; }
        IUtenteRepository Utente { get; }
        void Save();
    }
}
