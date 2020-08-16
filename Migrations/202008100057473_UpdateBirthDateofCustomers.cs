namespace MovieRentaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthDateofCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers Set BirthDate='1995/04/23' Where Name = 'John Smith' ");
            Sql("Update Customers Set BirthDate='1997/06/10' Where Name = 'Mary Williams'");
        }
        
        public override void Down()
        {
        }
    }
}
