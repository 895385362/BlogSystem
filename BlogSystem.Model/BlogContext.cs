namespace BlogSystem.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class BlogContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“BlogContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“BlogSystem.Model.BlogContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“BlogContext”
        //连接字符串。
        public BlogContext()
            : base("Con")
        {
            Database.SetInitializer<BlogContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        
        public DbSet<UserModel> Users { get; set; }

        public DbSet<BlogCategory> BlogCategories { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleToCategory> ArticleToCategories { get; set; }

        public DbSet<CommentModel> CommentModels { get; set; }

        public DbSet<Fans> Fans { get; set; }
    }
}