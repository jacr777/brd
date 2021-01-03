namespace BusinessRequirements.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002MigrationHLC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HLC",
                c => new
                    {
                        HLCId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        HLCNumber = c.Int(nullable: false),
                        HLCDescription = c.String(nullable: false, maxLength: 50),
                        ProjectId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.HLCId)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HLC", "ProjectId", "dbo.Project");
            DropIndex("dbo.HLC", new[] { "ProjectId" });
            DropTable("dbo.HLC");
        }
    }
}
