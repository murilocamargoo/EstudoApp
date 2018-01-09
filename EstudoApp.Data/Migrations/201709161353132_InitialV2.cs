namespace EstudoApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NinjaClan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClanName = c.String(maxLength: 200, unicode: false),
                        FoundationDate = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ninja",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NinjaName = c.String(maxLength: 200, unicode: false),
                        NinjaClanId = c.Int(),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NinjaClan", t => t.NinjaClanId)
                .Index(t => t.NinjaClanId);
            
            CreateTable(
                "dbo.NinjaEquipment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentName = c.String(maxLength: 200, unicode: false),
                        NinjaId = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ninja", t => t.NinjaId)
                .Index(t => t.NinjaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NinjaEquipment", "NinjaId", "dbo.Ninja");
            DropForeignKey("dbo.Ninja", "NinjaClanId", "dbo.NinjaClan");
            DropIndex("dbo.NinjaEquipment", new[] { "NinjaId" });
            DropIndex("dbo.Ninja", new[] { "NinjaClanId" });
            DropTable("dbo.NinjaEquipment");
            DropTable("dbo.Ninja");
            DropTable("dbo.NinjaClan");
        }
    }
}
