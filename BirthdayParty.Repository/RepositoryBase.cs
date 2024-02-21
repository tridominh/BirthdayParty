using BirthdayParty.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Repository
{
    public class RepositoryBase<T> where T : class
    {
        BookingPartyContext bookingPartyContext;
        DbSet<T> dbSet;

        public RepositoryBase()
        {
            bookingPartyContext = new BookingPartyContext();
            dbSet = bookingPartyContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Add(T item)
        {
            dbSet.Add(item);
            bookingPartyContext.SaveChanges();
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
            bookingPartyContext.SaveChanges();
        }

        public void Update(T item)
        {
            dbSet.Update(item);
            bookingPartyContext.SaveChanges();
        }
    }
}
