namespace Lab
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            //01. Clock
            for (int hours = 0; hours <= 23; hours++)
            {
                for (int minutes = 0; minutes <= 59; minutes++)
                {
                    Console.WriteLine($"{hours}:{minutes}");
                }
            }

            //02. Multiplication Table
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    int product = i * j;
                    Console.WriteLine($"{i} * {j} = {product}");
                }
            }

            //03. Combinations
            int n = int.Parse(Console.ReadLine());
            int combinations = 0;
            for (int x1 = 0; x1 <= n; x1++)
            {
                for (int x2 = 0; x2 <= n; x2++)
                {
                    for (int x3 = 0; x3 <= n; x3++)
                    {
                        if (x1 + x2 + x3 == n)
                        {
                            combinations++;
                        }
                    }
                }
            }
            Console.WriteLine(combinations);

            //04. Sum of Two Numbers
            int firstNum = int.Parse(Console.ReadLine());
            int lastNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int combinations = 0;
            bool isFound = false;

            for (int i = firstNum; i <= lastNum; i++)
            {
                for (int j = firstNum; j <= lastNum; j++)
                {
                    combinations++;
                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{combinations} ({i} + {j} = {magicNum})");
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }

            }
            if (!isFound)
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNum}");
            }

            //05. Travelling
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                double savings = 0;

                while (budget > savings)
                {
                    savings += double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
            }

            //06. Building
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int floor = floors; floor >= 1; floor--)
            {
                for (int room = 0; room < rooms; room++)
                {
                    if (floor == floors)
                    {
                        Console.Write($"L{floor}{room} ");
                    }
                    else if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{room} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{room} ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}