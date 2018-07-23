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
    public class Carr_EquipAppService : AppServiceBase<Carr_Equip, Carr_Equip_DTO>, IAppCarr_EquipService
    {

        private readonly ICarr_EquipService _Carr_EquipService;
        public Carr_EquipAppService(ICarr_EquipService Carr_EquipService)
            : base(Carr_EquipService)
        {
            _Carr_EquipService = Carr_EquipService;
        }

    }
}
