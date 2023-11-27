namespace sell_movie.Repository
{
    public interface IReposity<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
