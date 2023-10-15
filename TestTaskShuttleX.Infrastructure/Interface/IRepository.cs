namespace TestTaskShuttleX.Infrastructure.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(int id);
        Task<TEntity> FindByIdASync(int id);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
        void SaveAsync();
    }
}
