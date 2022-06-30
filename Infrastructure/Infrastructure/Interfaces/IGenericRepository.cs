using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll(string sql);
        void Insert(T param, string sql);
    }
}
