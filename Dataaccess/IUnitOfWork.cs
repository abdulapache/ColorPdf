using Dataaccess.IReprositiry;
using Dataaccess.Reprository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess
{
    public interface IUnitOfWork
    {
        public void Save();

        public CustomeRepo customerRepo { get; }

         
    }
}
