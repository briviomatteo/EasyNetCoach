using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.DataAccess.Repository.IRepository;
using EasyNet.Data;
using EasyNet.DataAccess.Repository;
using EasyNet.Models;

namespace Easy.DataAccess.Repository
{
    public class UtenteRepository : Repository<Utente>, IUtenteRepository
    {
        private readonly AppDbContext _db;
        public UtenteRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Utente utente)
        {
            _db.Utentes.Update(utente);
        }



    }
}
