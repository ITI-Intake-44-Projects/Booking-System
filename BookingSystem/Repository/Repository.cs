using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repository
{
    public class Repository<T>  : IRepository<T> where T : class
    {
        protected BookingContext context;
        public Repository(BookingContext _context)
        {
            context = _context;
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T Get(int id) 
        {
            return context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            context.Add(obj);
        }

        public void Update(T obj)
        {
            context.Set<T>().Update(obj);
        }

        public void Delete(int id)
        {
            T obj = Get(id);
            context.Set<T>().Remove(obj);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
