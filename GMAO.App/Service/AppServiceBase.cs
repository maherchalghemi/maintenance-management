using AutoMapper;
using GMAO.App.Interface;
using GMAO.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Service
{
    public class AppServiceBase<TEntity, TEntity_DTO> : IAppServiceBase<TEntity_DTO>
        where TEntity_DTO : class
        where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;
        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public bool Add(TEntity_DTO obj)
        {
            var obj_TDO = Mapper.Map<TEntity_DTO, TEntity>(obj);
            return _serviceBase.Add(obj_TDO);
        }

        public TEntity_DTO GetById(int id)
        {
            var entityAdapter = Mapper.Map<TEntity, TEntity_DTO>(_serviceBase.GetById(id));
            return entityAdapter;
        }

        public IEnumerable<TEntity_DTO> GetAll()
        {
            var entityAdapter = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntity_DTO>>(_serviceBase.GetAll());
            return entityAdapter;
        }

        public bool Update(TEntity_DTO obj)
        {
            var obj_TDO = Mapper.Map<TEntity_DTO, TEntity>(obj);
            return _serviceBase.Update(obj_TDO);
        }

        public bool Remove(int id)
        {
            //var obj_TDO = Mapper.Map<TEntity_DTO, TEntity>(id);
            return _serviceBase.Remove(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
