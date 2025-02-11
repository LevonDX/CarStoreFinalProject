using CarStore.Data.Data.Entities;
using CarStore.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Data
{
    public class CarStoreRepository<T> : ICarStoreRepository<T> where T : BaseEntity // generic repository pattern
    {
        ApplicationDbContext _context;

        public CarStoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity) // repository pattern
        {
            _context.Set<T>().Add(entity);
        }

        public void AddEntityToDB(T entity) // unit of work pattern
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void AddCars(T entity1, T entity2) // unit of work pattern
        {
            _context.Set<T>().Add(entity1);
            _context.Set<T>().Add(entity2);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
           return _context.Set<T>().FirstOrDefault(x => x.Id == id)!;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
