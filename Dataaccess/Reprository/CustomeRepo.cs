using Dataaccess.Entites;
using Dataaccess.IReprositiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Reprository
{
    public class CustomeRepo : Reprository<Customer>, ICustomer
    {
        private readonly RestaurantContext db;
        public CustomeRepo(RestaurantContext context) : base(context)
        {
            db = context;
        }

    }
}
