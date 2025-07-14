using FluentMigrator;

namespace AspTest.DataAccess.Migrations.MigrationFiles;
[Migration(202507141757)]
public class _202507141757_InitialTables : Migration 
{
    public override void Up()
    {
        Create.Table("Provinces")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(30).NotNullable();
        
        Create.Table("Counties")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(30).NotNullable()
            .WithColumn("ProvinceId").AsInt32().NotNullable();

        Create.ForeignKey("FK_Counties_Provinces")
            .FromTable("Counties").ForeignColumn("ProvinceId")
            .ToTable("Provinces").PrimaryColumn("Id")
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);

        Create.UniqueConstraint("UQ_Counties_Name_ProvinceId")
            .OnTable("Counties")
            .Columns("Name", "ProvinceId");

        Create.Table("EducationDistricts")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(30).NotNullable()
            .WithColumn("CountyId").AsInt32().NotNullable();

        Create.ForeignKey("FK_EducationDistricts_Counties")
            .FromTable("EducationDistricts").ForeignColumn("CountyId")
            .ToTable("Counties").PrimaryColumn("Id")
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);

        Create.UniqueConstraint("UQ_EducationDistricts_Name_CountyId")
            .OnTable("EducationDistricts")
            .Columns("Name", "CountyId");
        
        Execute.Sql("SET IDENTITY_INSERT Provinces ON");
        Insert.IntoTable("Provinces").Row(new { Id = 1, Name = "تهران" });
        Insert.IntoTable("Provinces").Row(new { Id = 2, Name = "اصفهان" });
        Execute.Sql("SET IDENTITY_INSERT Provinces OFF");

        
        Execute.Sql("SET IDENTITY_INSERT Counties ON");
        Insert.IntoTable("Counties").Row(new { Id = 1, Name = "تهران", ProvinceId = 1 });
        Insert.IntoTable("Counties").Row(new { Id = 2, Name = "ری", ProvinceId = 1 });
        Insert.IntoTable("Counties").Row(new { Id = 3, Name = "اصفهان", ProvinceId = 2 });
        Execute.Sql("SET IDENTITY_INSERT Counties OFF");

        Execute.Sql("SET IDENTITY_INSERT EducationDistricts ON");
        Insert.IntoTable("EducationDistricts").Row(new { Id = 1, Name = "ناحیه 1 تهران", CountyId = 1 });
        Insert.IntoTable("EducationDistricts").Row(new { Id = 2, Name = "ناحیه 2 تهران", CountyId = 1 });
        Insert.IntoTable("EducationDistricts").Row(new { Id = 3, Name = "ناحیه 3 ری", CountyId = 2 });
        Insert.IntoTable("EducationDistricts").Row(new { Id = 4, Name = "ناحیه 4 اصفهان", CountyId = 3 });
        Execute.Sql("SET IDENTITY_INSERT EducationDistricts OFF");
    }

    public override void Down()
    {
        Delete.Table("EducationDistricts");
        Delete.Table("Counties");
        Delete.Table("Provinces");
    }
}