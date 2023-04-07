namespace Lab
{
    public class Program
    {
        static void Main(string[] args)
        {
            //01. Day of Week
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;

            }

            //02.Weekend or Working Day
            string day = Console.ReadLine();
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    Console.WriteLine("Working day");
                    break;
                case "Saturday":
                case "Sunday":
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;

            }

            //03. Animal Type
            string animal = Console.ReadLine();
            switch (animal)
            {
                case "dog":
                    Console.WriteLine("mammal");
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    Console.WriteLine("reptile");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;

            }

            //04. Personal Titles
            double age = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            if (age >= 16)
            {
                switch (gender)
                {
                    case 'm':
                        Console.WriteLine("Mr.");
                        break;
                    case 'f':
                        Console.WriteLine("Ms.");
                        break;
                }
            }
            else if (age < 16)
            {
                switch (gender)
                {
                    case 'm':
                        Console.WriteLine("Master");
                        break;
                    case 'f':
                        Console.WriteLine("Miss");
                        break;
                }
            }

            //05. Small Shop
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            if (city == "Sofia")
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(quantity * 0.50);
                        break;
                    case "water":
                        Console.WriteLine(quantity * 0.80);
                        break;
                    case "beer":
                        Console.WriteLine(quantity * 1.20);
                        break;
                    case "sweets":
                        Console.WriteLine(quantity * 1.45);
                        break;
                    case "peanuts":
                        Console.WriteLine(quantity * 1.60);
                        break;

                }
            }
            else if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(quantity * 0.40);
                        break;
                    case "water":
                        Console.WriteLine(quantity * 0.70);
                        break;
                    case "beer":
                        Console.WriteLine(quantity * 1.15);
                        break;
                    case "sweets":
                        Console.WriteLine(quantity * 1.30);
                        break;
                    case "peanuts":
                        Console.WriteLine(quantity * 1.50);
                        break;

                }
            }
            else if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee":
                        Console.WriteLine(quantity * 0.45);
                        break;
                    case "water":
                        Console.WriteLine(quantity * 0.70);
                        break;
                    case "beer":
                        Console.WriteLine(quantity * 1.10);
                        break;
                    case "sweets":
                        Console.WriteLine(quantity * 1.35);
                        break;
                    case "peanuts":
                        Console.WriteLine(quantity * 1.55);
                        break;
                }
            }

            //06. Number in Range
            int number = int.Parse(Console.ReadLine());
            if (number >= -100 && number <= 100)
            {
                if (number == 0)
                {
                    Console.WriteLine("No");
                }
                else
                {
                    Console.WriteLine("Yes");
                }
            }
            else
            {
                Console.WriteLine("No");
            }

            //07.Working Hours
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            if (hour >= 10 && hour <= 18)
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                    case "Saturday":
                        Console.WriteLine("open");
                        break;

                    case "Sunday":
                        Console.WriteLine("closed");
                        break;
                }
            }
            else
            {
                Console.WriteLine("closed");
            }

            //08.Cinema Ticket
            string day = Console.ReadLine();
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                    Console.WriteLine("12");
                    break;
                case "Wednesday":
                case "Thursday":
                    Console.WriteLine("14");
                    break;
                case "Saturday":
                case "Sunday":
                    Console.WriteLine("16");
                    break;

            }

            //09. Fruit or Vegetable
            string product = Console.ReadLine();
            switch (product)
            {
                case "banana":
                case "apple":
                case "kiwi":
                case "cherry":
                case "lemon":
                case "grapes":
                    Console.WriteLine("fruit");
                    break;
                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot":
                    Console.WriteLine("vegetable");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }

            //10. Invalid Number
            int number = int.Parse(Console.ReadLine());
            bool isValid = number >= 100 && number <= 200 || number == 0;
            if (!isValid)
            {
                Console.WriteLine("invalid");
            }

            //11. Fruit Shop
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine("{0:F2}", (quantity * 2.50));
                        break;
                    case "apple":
                        Console.WriteLine("{0:F2}", (quantity * 1.20));
                        break;
                    case "orange":
                        Console.WriteLine("{0:F2}", (quantity * 0.85));
                        break;
                    case "grapefruit":
                        Console.WriteLine("{0:F2}", (quantity * 1.45));
                        break;
                    case "kiwi":
                        Console.WriteLine("{0:F2}", (quantity * 2.70));
                        break;
                    case "pineapple":
                        Console.WriteLine("{0:F2}", (quantity * 5.50));
                        break;
                    case "grapes":
                        Console.WriteLine("{0:F2}", (quantity * 3.85));
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine("{0:F2}", (quantity * 2.70));
                        break;
                    case "apple":
                        Console.WriteLine("{0:F2}", (quantity * 1.25));
                        break;
                    case "orange":
                        Console.WriteLine("{0:F2}", (quantity * 0.90));
                        break;
                    case "grapefruit":
                        Console.WriteLine("{0:F2}", (quantity * 1.60));
                        break;
                    case "kiwi":
                        Console.WriteLine("{0:F2}", (quantity * 3.00));
                        break;
                    case "pineapple":
                        Console.WriteLine("{0:F2}", (quantity * 5.60));
                        break;
                    case "grapes":
                        Console.WriteLine("{0:F2}", (quantity * 4.20));
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }

            //12. Trade Commissions
            string city = Console.ReadLine();
            double volumeSales = double.Parse(Console.ReadLine());
            if (volumeSales >= 0 && volumeSales <= 500)
            {
                switch (city)
                {
                    case "Sofia":
                        Console.WriteLine("{0:F2}", (0.05 * volumeSales));
                        break;
                    case "Varna":
                        Console.WriteLine("{0:F2}", (0.045 * volumeSales));
                        break;
                    case "Plovdiv":
                        Console.WriteLine("{0:F2}", (0.055 * volumeSales));
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }

            }
            else if (volumeSales > 500 && volumeSales <= 1000)
            {
                switch (city)
                {
                    case "Sofia":
                        Console.WriteLine("{0:F2}", (0.07 * volumeSales));
                        break;
                    case "Varna":
                        Console.WriteLine("{0:F2}", (0.075 * volumeSales));
                        break;
                    case "Plovdiv":
                        Console.WriteLine("{0:F2}", (0.08 * volumeSales));
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (volumeSales > 1000 && volumeSales <= 10000)
            {
                switch (city)
                {
                    case "Sofia":
                        Console.WriteLine("{0:F2}", (0.08 * volumeSales));
                        break;
                    case "Varna":
                        Console.WriteLine("{0:F2}", (0.1 * volumeSales));
                        break;
                    case "Plovdiv":
                        Console.WriteLine("{0:F2}", (0.12 * volumeSales));
                        break;
                    default:
                        Console.WriteLine("error");
                        break;

                }
            }
            else if (volumeSales > 10000)
            {
                switch (city)
                {
                    case "Sofia":
                        Console.WriteLine("{0:F2}", (0.12 * volumeSales));
                        break;
                    case "Varna":
                        Console.WriteLine("{0:F2}", (0.13 * volumeSales));
                        break;
                    case "Plovdiv":
                        Console.WriteLine("{0:F2}", (0.145 * volumeSales));
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}