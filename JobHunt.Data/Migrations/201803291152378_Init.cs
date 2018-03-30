using System.Data.Entity.Migrations;

namespace JobHunt.Data.Migrations
{
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        InsAt = c.DateTime(nullable: false),
                        InsBy = c.String(),
                        UpdAt = c.DateTime(nullable: false),
                        UpdBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attachment",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Data = c.Binary(),
                        Name = c.String(),
                        Size = c.Int(nullable: false),
                        Type = c.String(),
                        Extension = c.String(),
                        IncidentTitle = c.String(),
                        Description = c.String(),
                        IncidentType = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        InsAt = c.DateTime(nullable: false),
                        InsBy = c.String(),
                        UpdAt = c.DateTime(nullable: false),
                        UpdBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FacebookLink = c.String(),
                        TwitchLink = c.String(),
                        PhoneNumber = c.String(),
                        EmployerSiteUrl = c.String(),
                        ContactPoint = c.String(),
                        Office = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        InsAt = c.DateTime(nullable: false),
                        InsBy = c.String(),
                        UpdAt = c.DateTime(nullable: false),
                        UpdBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveriedEmail",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        From = c.String(nullable: false),
                        To = c.String(nullable: false),
                        Bcc = c.String(),
                        CC = c.String(),
                        Subject = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        ErrorCode = c.Int(nullable: false),
                        ErrorMessage = c.String(),
                        TrialCount = c.Int(nullable: false),
                        EmailTemplateName = c.String(),
                        SentDateTime = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        InsAt = c.DateTime(nullable: false),
                        InsBy = c.String(),
                        UpdAt = c.DateTime(nullable: false),
                        UpdBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailQueue",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        From = c.String(),
                        To = c.String(),
                        Bcc = c.String(),
                        CC = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        ErrorCode = c.Int(nullable: false),
                        ErrorMessage = c.String(),
                        TrialCount = c.Int(nullable: false),
                        EmailTemplateName = c.String(),
                        SentDateTime = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        InsAt = c.DateTime(nullable: false),
                        InsBy = c.String(),
                        UpdAt = c.DateTime(nullable: false),
                        UpdBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailTemplate",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TemplateName = c.String(),
                        ToList = c.String(),
                        From = c.String(),
                        CCList = c.String(),
                        BCCList = c.String(),
                        Subject = c.String(),
                        TemplateBody = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        InsAt = c.DateTime(nullable: false),
                        InsBy = c.String(),
                        UpdAt = c.DateTime(nullable: false),
                        UpdBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        OpenPosition = c.Int(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        LogoImage = c.String(),
                        LongDescription = c.Int(nullable: false),
                        Followers = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        InsAt = c.DateTime(nullable: false),
                        InsBy = c.String(),
                        UpdAt = c.DateTime(nullable: false),
                        UpdBy = c.String(),
                        Address_Id = c.Guid(),
                        Contact_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Address_Id)
                .ForeignKey("dbo.Contact", t => t.Contact_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.String(),
                        Position = c.String(),
                        RequiredSkill = c.String(),
                        Salary = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        InsAt = c.DateTime(nullable: false),
                        InsBy = c.String(),
                        UpdAt = c.DateTime(nullable: false),
                        UpdBy = c.String(),
                        Employers_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.Employers_Id)
                .Index(t => t.Employers_Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        InsAt = c.DateTime(nullable: false),
                        InsBy = c.String(),
                        UpdAt = c.DateTime(nullable: false),
                        UpdBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Domain = c.String(),
                        UserName = c.String(),
                        DisplayName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Department = c.String(),
                        Organization = c.String(),
                        Division = c.String(),
                        ContactNumber = c.String(),
                        MobileNumber = c.String(),
                        StaffNumber = c.String(),
                        Password = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        InsAt = c.DateTime(nullable: false),
                        InsBy = c.String(),
                        UpdAt = c.DateTime(nullable: false),
                        UpdBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        Role_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.User");
            DropForeignKey("dbo.Job", "Employers_Id", "dbo.Employers");
            DropForeignKey("dbo.Employers", "Contact_Id", "dbo.Contact");
            DropForeignKey("dbo.Employers", "Address_Id", "dbo.Address");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.Job", new[] { "Employers_Id" });
            DropIndex("dbo.Employers", new[] { "Contact_Id" });
            DropIndex("dbo.Employers", new[] { "Address_Id" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.Job");
            DropTable("dbo.Employers");
            DropTable("dbo.EmailTemplate");
            DropTable("dbo.EmailQueue");
            DropTable("dbo.DeliveriedEmail");
            DropTable("dbo.Contact");
            DropTable("dbo.Attachment");
            DropTable("dbo.Address");
        }
    }
}
