using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.BLL;
using BlogSystem.MVCSite.Filters;
using BlogSystem.MVCSite.Models.ArticleViewModels;

namespace BlogSystem.MVCSite.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [BlogSystemAuth]
        public ActionResult CreateCategory(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IArticleManager articleManager = new ArticleManager();
                articleManager.CreateCategory(model.CategoryName, Guid.Parse(Session["UserID"].ToString()));
                return RedirectToAction("CategoryList");
            }
            ModelState.AddModelError("", "您录入的信息有误");
            return View(model);
        }

        [HttpGet]
        [BlogSystemAuth]
        public async Task<ActionResult> CategoryList()
        {
            var userid = Guid.Parse(Session["UserID"].ToString());
            return View(await new ArticleManager().GetAllCategories(userid));

            //return View( await new ArticleManager().GetAllCategories(Guid.Parse(Session["UserID"].ToString())));
        }

        [HttpGet]
        [BlogSystemAuth]
        public async Task<ActionResult> CreateArticle()
        {
            var userid = Guid.Parse(Session["UserID"].ToString());
            ViewBag.CategoryIDs = await new ArticleManager().GetAllCategories(userid);
            return View();
        }

        [HttpPost]
        [BlogSystemAuth]
        public async Task<ActionResult> CreateArticle(Models.ArticleViewModels.CreateArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userid = Guid.Parse(Session["UserID"].ToString());
                await new ArticleManager().CreateArticle(model.Title, model.Content, model.CategoryIDs, userid);
                return RedirectToAction("ArticleList");
            }
            ModelState.AddModelError("", "添加失败");
            return View();
        }

        [HttpGet]
        [BlogSystemAuth]
        public async Task<ActionResult> ArticleList()
        {
            var userid = Guid.Parse(Session["UserID"].ToString());
            var articles = await new ArticleManager().GetAllArticlesByUserID(userid);
            return View(articles);
        }
    }
}