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
    public class CompanyAppService : AppServiceBase<Company, Company_DTO>, IAppCompanyService
    {

        private readonly ICompanyService _CompanyService;
        public CompanyAppService(ICompanyService CompanyService)
            : base(CompanyService)
        {
            _CompanyService = CompanyService;
        }

    }
}
