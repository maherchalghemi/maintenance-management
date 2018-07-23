using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces.Repository;
using GMAO.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Service
{
    public class Carr_EquipService : ServiceBase<Carr_Equip>, ICarr_EquipService
    {
        public Carr_EquipService(ICarr_EquipRepository carr_EquipRepository)
            : base(carr_EquipRepository)
        {

        }

    }
}
