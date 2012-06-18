using System.Collections.Generic;

namespace SilverlightExampleApp.Web.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);
        IList<T> GetAll();

        void Insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}