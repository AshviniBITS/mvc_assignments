namespace EFDBFirstDemoExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDBFirstDemoExample.Models.CompanyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EFDBFirstDemoExample.Models.CompanyDBContext";
        }

        protected override void Seed(EFDBFirstDemoExample.Models.CompanyDBContext context)
        {
            context.Brands.AddOrUpdate(new Models.Brand() { BrandId = 1, BrandName = "Apple" }, new Models.Brand() { BrandId = 2, BrandName = "Samsung" });
            context.Categories.AddOrUpdate(new Models.Category() { CategoryId = 1, CategoryName = "Mobile" }, new Models.Category() { CategoryId = 2, CategoryName = "Home Application" });


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
