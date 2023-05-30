
using Easy.DataAccess.Repository.IRepository;
using EasyNet.Data;
using EasyNet.DataAccess.Repository.IRepository;
using EasyNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNet.DataAccess.Repository.IRepository;
using Easy.DataAccess.Repository;

namespace EasyNet.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Post = new PostRepository(_db);
            Utente = new UtenteRepository(_db);
        }
        public IPostRepository Post { get; private set; } = null!;
        public IUtenteRepository Utente { get; private set; } = null!;

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
