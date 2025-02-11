using CarStore.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Data
{
    public interface ICarStoreRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        void Add(T entity);

        void SaveChanges();
    }
}
