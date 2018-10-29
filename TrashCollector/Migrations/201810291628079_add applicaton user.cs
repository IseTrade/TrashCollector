namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addapplicatonuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ApplicationCustId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "ApplicationEmployeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "ApplicationCustId");
            CreateIndex("dbo.Employees", "ApplicationEmployeeId");
            AddForeignKey("dbo.Customers", "ApplicationCustId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "ApplicationEmployeeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ApplicationEmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "ApplicationCustId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "ApplicationEmployeeId" });
            DropIndex("dbo.Customers", new[] { "ApplicationCustId" });
            DropColumn("dbo.Employees", "ApplicationEmployeeId");
            DropColumn("dbo.Customers", "ApplicationCustId");
        }
    }
}
