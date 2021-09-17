using Rezervasyon.Abstract;
using Rezervasyon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rezervasyon.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context db;
        DbSet<T> table;

        public GenericRepository()
        {
            db = new Context();
            table = db.Set<T>();
        }

        public T GetByID(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
            db.SaveChanges();
        }

        public List<T> List()
        {
            return table.ToList();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}