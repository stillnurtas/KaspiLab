using AdventureWorks.EF.Context;
using AdventureWorks.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Repositories
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(AWContext context) : base(context) { }
    }
}
