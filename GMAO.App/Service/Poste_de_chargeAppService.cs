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
    public class Poste_de_chargeAppService : AppServiceBase<Poste_de_charge, Poste_de_charge_DTO>, IAppPoste_de_chargeService
    {

        private readonly IPoste_de_chargeService _Poste_de_chargeService;
        public Poste_de_chargeAppService(IPoste_de_chargeService Poste_de_chargeService)
            : base(Poste_de_chargeService)
        {
            _Poste_de_chargeService = Poste_de_chargeService;
        }

    }
}
