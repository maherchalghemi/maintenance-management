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
    public class TestSchedulerAppService : AppServiceBase<TestScheduler, TestScheduler_DTO>, IAppTestSchedulerService
    {

        private readonly ITestSchedulerService _TestSchedulerService;
        public TestSchedulerAppService(ITestSchedulerService TestSchedulerService)
            : base(TestSchedulerService)
        {
            _TestSchedulerService = TestSchedulerService;
        }

    }
}
