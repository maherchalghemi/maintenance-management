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
    public class CategoryAppService : AppServiceBase<Category, Category_DTO>, IAppCategoryService
    {

        private readonly ICategoryService _CategoryService;
        public CategoryAppService(ICategoryService CategoryService)
            : base(CategoryService)
        {
            _CategoryService = CategoryService;
        }

    }
}
