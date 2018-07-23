using GMAO.Domain.Interfaces.Repository;
using GMAO.Infra.data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected GmaoContext Db = new GmaoContext();

        public bool Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            if (Db.SaveChanges() > 0)
            {
                return true;
            }
            else
                return false;
        }

        public TEntity GetById(Int32 id = 0)
        {
            return Db.Set<TEntity>().Find(id);
        }



        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public bool Update(TEntity obj)
        {

            //var obj = Db.Set<TEntity>().Find(id);
            // Db.Entry(obj).State = EntityState.Modified;
            //if (Db.SaveChanges() > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            try
            {
                using (var dbCtx = new GmaoContext())
                {
                    //3. Mark entity as modified
                    dbCtx.Entry(obj).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    dbCtx.SaveChanges();                    
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool Remove(int id)
        {
            //var obj = Db.Set<TEntity>().Find(id);
            ////Db.Entry(obj2).State = EntityState.Deleted;
            //Db.Set<TEntity>().Remove(obj);
            //if (Db.SaveChanges() > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            try
            {
                using (var dbCtx = new GmaoContext())
                {
                    var obj = Db.Set<TEntity>().Find(id);
                    //3. Mark entity as modified
                    dbCtx.Entry(obj).State = System.Data.Entity.EntityState.Deleted;

                    //4. call SaveChanges
                    dbCtx.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
