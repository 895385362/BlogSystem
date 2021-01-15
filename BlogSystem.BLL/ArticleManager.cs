using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.DAL;
using BlogSystem.Dto;
using BlogSystem.IBLL;
using BlogSystem.IDAL;
using BlogSystem.Model;

namespace BlogSystem.BLL
{
    public class ArticleManager : IArticleManager
    {
        public async Task CreateArticle(string title, string content, Guid[] categoryIDs, Guid userID)
        {
            using (var articleSvc = new ArticleService())
            {
                var article = new Article()
                {
                    Title = title,
                    Content = content,
                    UserID = userID
                };
                await articleSvc.CreateAsync(article);

                Guid articleID = article.ID;
                using (var articleToCategorySvc = new ArticleToCategoryService())
                {
                    foreach (var categoryID in categoryIDs)
                    {
                        await articleToCategorySvc.CreateAsync(new ArticleToCategory()
                        {
                            ArticleID = articleID,
                            CategoryID = categoryID
                        }, saved: false);
                    }
                    await articleToCategorySvc.Save();
                }
            }
        }

        public async Task CreateCategory(string name, Guid userID)
        {
            using (var categorySvc = new BlogCategoryService())
            {
                await categorySvc.CreateAsync(new BlogCategory()
                {
                    CategoryName = name,
                    UserID = userID
                });
            }
        }

        public async Task EditArticle(Guid articleID, string title, string content, Guid[] categoryIDs)
        {
            throw new NotImplementedException();
        }

        public async Task EditCategory(Guid categoryID, string newCategoryName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticleDto>> GetAllArticles(Guid userID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticleDto>> GetAllArticlesByCategoryID(Guid categoryID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArticleDto>> GetAllArticlesByEmail(Guid email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BlogCategoryDto>> GetAllCategories(Guid userID)
        {
            using (IDAL.IBlogCategoryService categoryService = new BlogCategoryService())
            {
                return await categoryService.GetAllAsync().Where(m => m.UserID == userID).Select(m => new Dto.BlogCategoryDto()
                {
                    ID = m.ID,
                    CategoryName = m.CategoryName
                }).ToListAsync();
            }
        }

        public async Task<List<ArticleDto>> GetAllArticlesByUserID(Guid userid)
        {
            using (var articleSvc = new ArticleService())
            {
                var list = await articleSvc.GetAllAsync().Include(m => m.User).Where(m => m.UserID == userid)
                    .Select(m => new Dto.ArticleDto()
                    {
                        Title = m.Title,
                        BadCount = m.BadCount,
                        GoodCount = m.GoodCount,
                        Email = m.User.Email,
                        Content = m.Content,
                        CreateTime = m.CreateTime,
                        ID = m.ID,
                        ImagePath = m.User.ImagePath
                    })
                    .ToListAsync();
                using (IArticleToCategoryService articleToCategoryService = new ArticleToCategoryService())
                {
                    foreach(var articleDto in list)
                    {
                        var cates = await articleToCategoryService.GetAllAsync().Include(m => m.BlogCategory).Where(m => m.ArticleID == articleDto.ID).ToListAsync();
                        articleDto.CategoryIDs = cates.Select(m => m.CategoryID).ToArray();
                        articleDto.CategoryNames = cates.Select(m => m.BlogCategory.CategoryName).ToArray();
                    }
                    return list;
                }
            }
        }

        public async Task RemoveArticle(Guid articleID)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveCategory(string name)
        {
            throw new NotImplementedException();
        }
    }
}
