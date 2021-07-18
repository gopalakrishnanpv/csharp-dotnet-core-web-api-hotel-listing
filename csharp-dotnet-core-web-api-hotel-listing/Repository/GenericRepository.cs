using csharp_dotnet_core_web_api_hotel_listing.Data;
using csharp_dotnet_core_web_api_hotel_listing.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace csharp_dotnet_core_web_api_hotel_listing.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly DatabaseContext _context;
        private DbSet<T> _db;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes)
        {
            IQueryable<T> records = _db;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    records = records.Include(include);
                }
            }

            return await records.AsNoTracking().FirstOrDefaultAsync(expression);

        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null)
        {
            IQueryable<T> records = _db;

            if (expression != null)
            {
                records = records.Where(expression);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    records = records.Include(include);
                }
            }

            if (orderBy != null)
            {
                records = orderBy(records);
            }

            return await records.AsNoTracking().ToListAsync();
        }
    }
}
