using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Models.Base;
using TargetWebApi.Models.Context;

namespace TargetWebApi.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SQLContext _context;
        private DbSet<T> dataSet;
        public GenericRepository(SQLContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var res = dataSet.SingleOrDefault(p => p.ID.Equals(id));

                if (res != null)
                {
                    dataSet.Remove(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Exists(int id)
        {
            return dataSet.Any(p => p.ID.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindByID(int id)
        {
            return dataSet.SingleOrDefault(p => p.ID.Equals(id));
        }

        public T Update(T item)
        {
            try
            {
                if (Exists(item.ID))
                {
                    var res = dataSet.SingleOrDefault(p => p.ID.Equals(item.ID));

                    _context.Entry(res).CurrentValues.SetValues(item);
                    _context.SaveChanges();

                    return dataSet.LastOrDefault();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
