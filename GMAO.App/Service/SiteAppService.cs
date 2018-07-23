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
    public class SiteAppService : AppServiceBase<Site, Site_DTO>, IAppSiteService
    {

        private readonly ISiteService _SiteService;
        public SiteAppService(ISiteService SiteService)
            : base(SiteService)
        {
            _SiteService = SiteService;
        }

    }
}
