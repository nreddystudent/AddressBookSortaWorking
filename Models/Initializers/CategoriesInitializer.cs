using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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

            var conn = new SqlConnection("data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|\\Database1.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework");
            SqlCommand command = new SqlCommand("Create View ContactsView AS SELECT Contacts.[First Name], Contacts.[Last Name], Contacts.Email, Contacts.[Phone Number], Contacts.Favourite, Contacts.UserID FROM Contacts", conn);
            conn.Open();
            command.ExecuteScalar();
            conn.Close(); 
            SqlCommand command1 = new SqlCommand("CREATE PROCEDURE SelectContacts @UserID int AS SELECT * FROM ContactsView WHERE ContactsView.UserID = @UserID", conn);
            conn.Open();
            command1.ExecuteScalar();
            conn.Close();

            foreach (var category in categoryList)
                context.Categories.Add(category);

            base.Seed(context);
        }
    }

}