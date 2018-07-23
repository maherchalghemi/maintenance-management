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
    public class Poste_de_chargeService : ServiceBase<Poste_de_charge>, IPoste_de_chargeService
    {
        public Poste_de_chargeService(IPoste_de_chargeRepository poste_de_chargeRepository)
            : base(poste_de_chargeRepository)
        {

        }

    }
}
