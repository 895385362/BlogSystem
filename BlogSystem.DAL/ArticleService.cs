using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.IDAL;
using BlogSystem.Model;

namespace BlogSystem.DAL
{
    public class ArticleService : BaseService<Model.Article>,IArticleService
    {
        public ArticleService() : base(new BlogContext())
        {

        }
    }
}
