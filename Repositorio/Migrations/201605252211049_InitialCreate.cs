namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Nombre);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Nombre = c.String(maxLength: 128, storeType: "nvarchar"),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marca", t => t.Nombre)
                .Index(t => t.Nombre);
            
            CreateTable(
                "dbo.Precio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        PrecioMinimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioMaximo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Material_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Material", t => t.Material_Id)
                .Index(t => t.Material_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Precio", "Material_Id", "dbo.Material");
            DropForeignKey("dbo.Material", "Nombre", "dbo.Marca");
            DropIndex("dbo.Precio", new[] { "Material_Id" });
            DropIndex("dbo.Material", new[] { "Nombre" });
            DropTable("dbo.Precio");
            DropTable("dbo.Material");
            DropTable("dbo.Marca");
        }
    }
}