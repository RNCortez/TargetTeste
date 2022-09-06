using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetWebApi.Models;
using TargetWebApi.Models.Base;

namespace TargetWebApi.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(int id);
        List<T> FindAll();
        T Update(T item);
        void Delete(int id);
        bool Exists(int id);

    }
}
