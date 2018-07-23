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
    public class EquipementAppService : AppServiceBase<Equipement, Equipement_DTO>, IAppEquipementService
    {

        private readonly IEquipementService _EquipementService;
        public EquipementAppService(IEquipementService EquipementService)
            : base(EquipementService)
        {
            _EquipementService = EquipementService;
        }

    }
}
