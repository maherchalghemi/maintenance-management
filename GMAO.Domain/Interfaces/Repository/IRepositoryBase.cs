using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        bool Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity obj);
        bool Remove(int id);
        void Dispose();
    }
}
