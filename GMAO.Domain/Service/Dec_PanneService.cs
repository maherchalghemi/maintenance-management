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
    public class Dec_PanneService : ServiceBase<Dec_Panne>, IDec_PanneService
    {
        public Dec_PanneService(IDec_PanneRepository dec_PanneRepository)
            : base(dec_PanneRepository)
        {

        }

    }
}
