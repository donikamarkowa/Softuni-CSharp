namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string ageRestriction = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(db, ageRestriction);
            //Console.WriteLine(result);

            //string result = GetGoldenBooks(db); 
            //Console.WriteLine(result);

            string result = GetBooksByPrice(db);
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

        //Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookTitles = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var bookTitlesAndPrices = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var b in bookTitlesAndPrices)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


