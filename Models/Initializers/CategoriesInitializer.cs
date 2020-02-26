using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class CategoriesInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            var categoryList = new List<Categories>();

            categoryList.Add(new Categories() { CategoriesID = 1, Category = "Homies" });
            categoryList.Add(new Categories() { CategoriesID = 2, Category = "Fam" });
            categoryList.Add(new Categories() { CategoriesID = 3, Category = "Boomers" });
            categoryList.Add(new Categories() { CategoriesID = 4, Category = "Hookups" });
            categoryList.Add(new Categories() { CategoriesID = 5, Category = "Randos" });

            foreach (var category in categoryList)
                context.Categories.Add(category);

            base.Seed(context);
        }
    }

}