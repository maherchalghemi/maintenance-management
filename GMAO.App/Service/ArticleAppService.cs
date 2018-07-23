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
    public class ArticleAppService : AppServiceBase<Article, Article_DTO>, IAppArticleService
    {

        private readonly IArticleService _ArticleService;
        public ArticleAppService(IArticleService ArticleService)
            : base(ArticleService)
        {
            _ArticleService = ArticleService;
        }

    }
}
