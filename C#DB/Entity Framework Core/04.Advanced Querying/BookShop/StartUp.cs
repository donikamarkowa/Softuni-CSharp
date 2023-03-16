namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string ageRestriction = Console.ReadLine();
            string result = GetBooksByAgeRestriction(db, ageRestriction);
            Console.WriteLine(result);
        }

        //Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            try
            {
                AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

                var bookTitles =  context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .Select(b => b.Title)
                    .OrderBy(t => t)
                    .ToArray();

                return string.Join(Environment.NewLine, bookTitles);
            }
            catch 
            {
                return null;
            }
        }
    }
}


