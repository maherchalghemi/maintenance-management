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
    public class Ordre_de_travailService : ServiceBase<Ordre_de_travail>, IOrdre_de_travailService
    {
        public Ordre_de_travailService(IOrdre_de_travailRepository ordre_de_travailRepository)
            : base(ordre_de_travailRepository)
        {

        }

    }
}
