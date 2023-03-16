namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore.Metadata.Conventions;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
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

            //string result = GetBooksByPrice(db);
            //Console.WriteLine(result);

            //int year = int.Parse(Console.ReadLine());
            //string result = GetBooksNotReleasedIn(db, year);
            //Console.WriteLine(result);

            //string categories = Console.ReadLine();
            //string result = GetBooksByCategory(db, categories);
            //Console.WriteLine(result);

            //string date = Console.ReadLine();
            //string result = GetBooksReleasedBefore(db, date);
            //Console.WriteLine(result);

            //string str = Console.ReadLine();
            //string result = GetBookTitlesContaining(db, str);
            //Console.WriteLine(result);

            //string input = Console.ReadLine();
            //string result = GetBooksByAuthor(db, input);
            //Console.WriteLine(result);

            //int number = int.Parse(Console.ReadLine()); 
            //int result = CountBooks(db, number);    
            //Console.WriteLine(result);

            //string result = CountCopiesByAuthor(db);
            //Console.WriteLine(result);

            //string result = GetTotalProfitByCategory(db);
            //Console.WriteLine(result);

            string result = GetMostRecentBooks(db);
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

        //Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var notReleasedBooks = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, notReleasedBooks);
        }

        //Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var bookTitles = context
                .Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var bookReleasedBeforeDate = context
                .Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var b in bookReleasedBeforeDate)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsNames = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(a => a)
                .ToArray();

            return string.Join(Environment.NewLine, authorsNames);

        }

        //Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksWithAuthors = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, booksWithAuthors);
        }

        //Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksTitles = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToArray();

            return booksTitles.Count();
        }

        //Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var booksCopies = context
                .Authors
                .OrderByDescending(a => a.Books.Sum(b => b.Copies))
                .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}")
                .ToArray();

            return string.Join(Environment.NewLine, booksCopies);
        }

        //Problem 13
        static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var totalProfit = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
               .OrderByDescending(c => c.TotalProfit)
               .ThenBy(c => c.CategoryName)
               .ToArray();

            foreach (var c in totalProfit)
            {
                sb.AppendLine($"{c.CategoryName} ${c.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var recentBooks = context
                .Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostRecentBooks = context
                            .BooksCategories
                            .Where(bc => bc.Category == c)
                            .OrderByDescending(bc => bc.Book.ReleaseDate)
                            .Select(bc => new
                            {
                                BookName = bc.Book.Title,
                                YearPublished = bc.Book.ReleaseDate.Value.Year
                            })
                            .Take(3)
                            .ToArray()
                })
                .ToArray();

            foreach (var c in recentBooks)
            {
                sb.AppendLine($"--{c.CategoryName}");

                foreach (var b in c.MostRecentBooks)
                {
                    sb.AppendLine($"{b.BookName} ({b.YearPublished})");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}


