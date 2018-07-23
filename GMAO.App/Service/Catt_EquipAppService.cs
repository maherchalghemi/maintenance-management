using GMAO.App.Entities;
using GMAO.App.Interface;
using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Service
{
    public class Catt_EquipAppService : AppServiceBase<Catt_Equip, Catt_Equip_DTO>, IAppCatt_EquipService
    {

        private readonly ICatt_EquipService _Catt_EquipService;
        public Catt_EquipAppService(ICatt_EquipService Catt_EquipService)
            : base(Catt_EquipService)
        {
            _Catt_EquipService = Catt_EquipService;
        }

    }
}
