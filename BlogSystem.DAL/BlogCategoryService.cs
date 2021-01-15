using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.IDAL;
using BlogSystem.Model;

namespace BlogSystem.DAL
{
    public class BlogCategoryService : BaseService<Model.BlogCategory>,IBlogCategoryService
    {
        //构造函数
        public BlogCategoryService() : base(new BlogContext())
        {

        }
    }
}
