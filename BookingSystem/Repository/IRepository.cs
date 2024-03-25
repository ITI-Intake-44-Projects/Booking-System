namespace BookingSystem.Repository
{
    public interface IRepository<T> where T : class
    {
        
        public List<T> GetAll();

        public T Get(int id);

        public void Insert(T obj);

        public void Update(T obj);

        public void Delete(int id);

        public int Save();
    }
}
