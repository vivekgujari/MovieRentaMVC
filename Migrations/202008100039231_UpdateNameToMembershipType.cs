namespace MovieRentaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name = 'PayAsYouGo'  WHERE DurationInMonths = 0");
            Sql("Update MembershipTypes SET Name = 'Monthly'  WHERE DurationInMonths = 1");
            Sql("Update MembershipTypes SET Name = 'Quaterly' WHERE DurationInMonths = 3");
            Sql("Update MembershipTypes SET Name = 'Yearly' WHERE DurationInMonths = 12");
        }
        
        public override void Down()
        {
        }
    }
}
