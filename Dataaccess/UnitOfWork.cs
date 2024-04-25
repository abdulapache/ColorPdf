using Dataaccess.Entites;
using Dataaccess.IReprositiry;
using Dataaccess.Reprository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext db;

        public UnitOfWork(RestaurantContext db)
        {
            this.db = db;

            customerRepo = new CustomeRepo(db);
        }
        public CustomeRepo customerRepo { get; private set; }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
