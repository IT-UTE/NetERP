namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        TokenId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AuthToken = c.String(nullable: false, maxLength: 250),
                        IssuedOn = c.DateTime(nullable: false),
                        ExpiresOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TokenId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tokens");
            DropTable("dbo.Products");
        }
    }
}
