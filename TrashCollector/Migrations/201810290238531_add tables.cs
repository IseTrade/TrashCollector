namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberAndStreet = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        AddressId = c.Int(),
                        UserName = c.String(),
                        PickupDay = c.Int(nullable: false),
                        PickupStartDate = c.DateTime(),
                        PickupEndDate = c.DateTime(),
                        SpecialPickup = c.DateTime(),
                        SuspendStartDate = c.DateTime(),
                        SuspendEndDate = c.DateTime(),
                        MoneyOwed = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(),
                        EmployeeNumber = c.Int(nullable: false),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickupDate = c.DateTime(),
                        DayOfWeekPickup = c.Int(nullable: false),
                        PickupStatus = c.Boolean(nullable: false),
                        PickupCharge = c.Double(nullable: false),
                        Zipcode = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pickups", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Pickups", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Pickups", new[] { "CustomerId" });
            DropIndex("dbo.Pickups", new[] { "EmployeeId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropTable("dbo.Pickups");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
