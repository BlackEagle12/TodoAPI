using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Repo
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> FindByIdAsync(int id);
        Task<T> UpdateAsync(T item);
        Task<T> InsertAsync(T item);
        Task<T> DeleteAsync (int id);
        Task<List<T>?> UpdateCollectionAsync(List<T>? item);
        Task<List<T>?> InsertCollectionAsync(List<T>? item);
        Task<bool> DeleteCollectionAsync (List<T>? id);
        Task<IDbContextTransaction> StartTransaction();
        Task CommitTransaction(IDbContextTransaction transaction);
        Task RollBackTransaction(IDbContextTransaction transaction);
    }
}
