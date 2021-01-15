namespace BlogSystem.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createBlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        UserID = c.Guid(nullable: false),
                        GoodCount = c.Int(nullable: false),
                        BadCount = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserModels", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 40, unicode: false),
                        Password = c.String(nullable: false, maxLength: 30, unicode: false),
                        ImagePath = c.String(nullable: false, maxLength: 300, unicode: false),
                        FunsCount = c.Int(nullable: false),
                        FocusCount = c.Int(nullable: false),
                        SiteName = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ArticleToCategories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CategoryID = c.Guid(nullable: false),
                        ArticleID = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Articles", t => t.ArticleID)
                .ForeignKey("dbo.BlogCategories", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.ArticleID);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CategoryName = c.String(),
                        UserID = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserModels", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.CommentModels",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Content = c.String(nullable: false, maxLength: 800),
                        ArticleID = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Articles", t => t.ArticleID)
                .ForeignKey("dbo.UserModels", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ArticleID);
            
            CreateTable(
                "dbo.Fans",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        FocusUserID = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserModels", t => t.FocusUserID)
                .ForeignKey("dbo.UserModels", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.FocusUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fans", "UserID", "dbo.UserModels");
            DropForeignKey("dbo.Fans", "FocusUserID", "dbo.UserModels");
            DropForeignKey("dbo.CommentModels", "UserID", "dbo.UserModels");
            DropForeignKey("dbo.CommentModels", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.ArticleToCategories", "CategoryID", "dbo.BlogCategories");
            DropForeignKey("dbo.BlogCategories", "UserID", "dbo.UserModels");
            DropForeignKey("dbo.ArticleToCategories", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Articles", "UserID", "dbo.UserModels");
            DropIndex("dbo.Fans", new[] { "FocusUserID" });
            DropIndex("dbo.Fans", new[] { "UserID" });
            DropIndex("dbo.CommentModels", new[] { "ArticleID" });
            DropIndex("dbo.CommentModels", new[] { "UserID" });
            DropIndex("dbo.BlogCategories", new[] { "UserID" });
            DropIndex("dbo.ArticleToCategories", new[] { "ArticleID" });
            DropIndex("dbo.ArticleToCategories", new[] { "CategoryID" });
            DropIndex("dbo.Articles", new[] { "UserID" });
            DropTable("dbo.Fans");
            DropTable("dbo.CommentModels");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.ArticleToCategories");
            DropTable("dbo.UserModels");
            DropTable("dbo.Articles");
        }
    }
}
