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
    public class ConsMaintEquipementAppService : AppServiceBase<ConsMaintEquipement, ConsMaintEquipement_DTO>, IAppConsMaintEquipementService
    {

        private readonly IConsMaintEquipementService _ConsMaintEquipementService;
        public ConsMaintEquipementAppService(IConsMaintEquipementService ConsMaintEquipementService)
            : base(ConsMaintEquipementService)
        {
            _ConsMaintEquipementService = ConsMaintEquipementService;
        }

    }
}
