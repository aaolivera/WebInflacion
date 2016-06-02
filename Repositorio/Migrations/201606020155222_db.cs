namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Marca = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Precio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        PrecioMinimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioMaximo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Material_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Material", t => t.Material_Id)
                .Index(t => t.Material_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Precio", "Material_Id", "dbo.Material");
            DropIndex("dbo.Precio", new[] { "Material_Id" });
            DropTable("dbo.Precio");
            DropTable("dbo.Material");
        }
    }
}
