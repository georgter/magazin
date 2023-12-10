using Microsoft.EntityFrameworkCore;

namespace magazin.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _set;

        public Repository(DbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _set.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
        }

        public TEntity GetById(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _set.ToList();
        }
    }
}
