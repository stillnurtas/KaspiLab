using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AdventureWorks.DataAccess.Interfaces;
using AdventureWorks.DataAccess.Models.AWModels;
using AdventureWorks.DataAccess.Context;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.DataAccess.Repositories
{
    class AddressRepository : IRepository<Address>
    {
        protected readonly AWContext _context;
        private bool disposed = false;

        public AddressRepository()
        {
            _context = new AWContext();
        }

        public void Create(Address item)
        {
            _context.Addresses.Add(item);
        }

        public Address Get(int id)
        {
            return _context.Addresses.Find(id);
        }
        public IEnumerable GetList()
        {
            return _context.Addresses.ToList();
        }

        public IEnumerable GetList(Expression<Func<Address, bool>> predicate)
        {
            return _context.Addresses.Where(predicate).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
