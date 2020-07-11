
namespace EntityFrameworks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        UserId = c.Int(nullable: false),
                        Active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountName)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(),
                        Description = c.String(),
                        Image = c.String(),
                        Role = c.Int(nullable: false),
                        NewsId = c.Int(nullable: false),
                        AccountName = c.String(maxLength: 128),
                        Active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Accounts", t => t.AccountName)
                .ForeignKey("dbo.Newspapers", t => t.NewsId, cascadeDelete: true)
                .Index(t => t.NewsId)
                .Index(t => t.AccountName);
            
            CreateTable(
                "dbo.Newspapers",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        PublicationDate = c.DateTime(),
                        Description = c.String(),
                        Image = c.String(),
                        Title = c.String(),
                        Journalist = c.String(maxLength: 128),
                        Active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsId)
                .ForeignKey("dbo.Accounts", t => t.Journalist)
                .Index(t => t.Journalist);
            
            CreateTable(
                "dbo.Mappings",
                c => new
                    {
                        MappingId = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        NewsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MappingId)
                .ForeignKey("dbo.Newspapers", t => t.NewsId, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId)
                .Index(t => t.NewsId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        TopicName = c.String(),
                    })
                .PrimaryKey(t => t.TopicId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Description = c.String(),
                        Time = c.DateTime(nullable: false),
                        AccountId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Comments", "NewsId", "dbo.Newspapers");
            DropForeignKey("dbo.Mappings", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Mappings", "NewsId", "dbo.Newspapers");
            DropForeignKey("dbo.Newspapers", "Journalist", "dbo.Accounts");
            DropForeignKey("dbo.Comments", "AccountName", "dbo.Accounts");
            DropIndex("dbo.Feedbacks", new[] { "AccountId" });
            DropIndex("dbo.Mappings", new[] { "NewsId" });
            DropIndex("dbo.Mappings", new[] { "TopicId" });
            DropIndex("dbo.Newspapers", new[] { "Journalist" });
            DropIndex("dbo.Comments", new[] { "AccountName" });
            DropIndex("dbo.Comments", new[] { "NewsId" });
            DropIndex("dbo.Accounts", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Topics");
            DropTable("dbo.Mappings");
            DropTable("dbo.Newspapers");
            DropTable("dbo.Comments");
            DropTable("dbo.Accounts");
        }
    }
}
