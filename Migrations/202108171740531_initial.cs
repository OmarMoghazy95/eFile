namespace EFileTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image_Data",
                c => new
                    {
                        Image_Data_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Image_Path = c.String(),
                        Image_Blob = c.Binary(),
                    })
                .PrimaryKey(t => t.Image_Data_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Image_Data");
        }
    }
}
