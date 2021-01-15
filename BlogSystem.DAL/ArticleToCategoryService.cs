using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.IDAL;

namespace BlogSystem.DAL
{
    public class ArticleToCategoryService : BaseService<Model.ArticleToCategory>,IArticleToCategoryService
    {
        public ArticleToCategoryService() : base(new Model.BlogContext())
        {

        }
    }
}
