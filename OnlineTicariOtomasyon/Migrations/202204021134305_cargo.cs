namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Code = c.String(),
                        Employee = c.String(),
                        Receiver = c.String(),
                        Date = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailId);
            
            CreateTable(
                "dbo.CargoOperations",
                c => new
                    {
                        CargoOperationId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoOperationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoOperations");
            DropTable("dbo.CargoDetails");
        }
    }
}
