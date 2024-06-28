using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics.CodeAnalysis;
using Todo.Data.DBContext;

namespace Todo.Repo
{
    public class Repo<T> : IGenericRepo<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly TodoContext _context;

        public Repo(TodoContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task CommitTransaction(IDbContextTransaction transaction)
        {
            if (transaction != null)
            {
                await transaction.CommitAsync();
                transaction.Dispose();
            }
            else
            {
                throw new InvalidOperationException("transaction can not be null");
            }
        }

        public async Task RollBackTransaction(IDbContextTransaction transaction)
        {
            if (transaction != null)
            {
                await transaction.RollbackAsync();
                transaction.Dispose();
            }
            else
            {
                throw new InvalidOperationException("transaction can not be null");
            }
        }
        
        public async Task<IDbContextTransaction> StartTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }
        
        public async Task<T?> FindByIdAsync(int id)
        {
            return  await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>?> InsertCollectionAsync(List<T>? items)
        {
            if(items != null && items.Any())
                await _dbSet.AddRangeAsync(items);

            await _context.SaveChangesAsync();
            return items;
        }

        public async Task<List<T>?> UpdateCollectionAsync(List<T>? items)
        {
            if (items != null && items.Any())
            {
                _dbSet.UpdateRange(items);
            }
            await _context.SaveChangesAsync();
            return items;
        }
        
        public async Task<bool> DeleteCollectionAsync(List<T>? items)
        {
            if (items != null && items.Any())
            {
                _dbSet.RemoveRange(items);
            }
            return await _context.SaveChangesAsync() >= items.Count;
        }

        public async Task<T> InsertAsync([NotNull] T item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateAsync([NotNull] T item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await FindByIdAsync(id);

            if (entity == null)
                throw new Exception("Entity not found");

            _dbSet.Remove(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
