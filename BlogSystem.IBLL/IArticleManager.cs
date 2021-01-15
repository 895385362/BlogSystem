using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.IBLL
{
    public interface IArticleManager
    {
        Task CreateArticle(string title, string content, Guid[] categoryIDs, Guid userID);

        Task CreateCategory(string name , Guid userID);

        Task<List<Dto.BlogCategoryDto>> GetAllCategories(Guid userID);

        Task<List<Dto.ArticleDto>> GetAllArticles(Guid userID);

        Task<List<Dto.ArticleDto>> GetAllArticlesByEmail(Guid email);

        Task<List<Dto.ArticleDto>> GetAllArticlesByCategoryID(Guid categoryID);

        Task RemoveCategory(string name);

        Task EditCategory(Guid categoryID , string newCategoryName);

        Task RemoveArticle(Guid articleID);

        Task EditArticle(Guid articleID , string title , string content , Guid[] categoryIDs);
    }
}
