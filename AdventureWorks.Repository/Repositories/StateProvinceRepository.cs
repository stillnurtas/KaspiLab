using AdventureWorks.EF.Contexts;
using AdventureWorks.EF.Models;
using AdventureWorks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Repositories
{
    public class StateProvinceRepository : Repository<StateProvince>, IStateProvinceRepository
    {
        public StateProvinceRepository(AWContext context) : base(context) { }
    }
}
