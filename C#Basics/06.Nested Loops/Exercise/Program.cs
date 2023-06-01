namespace Exercise
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            //01. Number Pyramid
            int n = int.Parse(Console.ReadLine());
            int current = 1;
            bool isBigger = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    if (current > n)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write(current + " ");
                    current++;

                }
                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }

            //02. Equal Sums Even Odd Position
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int i = firstNum; i <= secondNum; i++)
            {
                int currentNum = i;
                int oddSum = 0;
                int evenSum = 0;
                bool isEven = true;
                while (currentNum > 0)
                {
                    int digit = currentNum % 10;
                    if (isEven)
                    {
                        evenSum += digit;
                    }
                    else
                    {
                        oddSum += digit;
                    }
                    currentNum /= 10;
                    isEven = !isEven;
                }
                if (evenSum == oddSum)
                {
                    Console.Write($"{i} ");
                }
            }

            //03. Sum Prime Non Prime
            int primeSum = 0;
            int nonPrimeSum = 0;

            string input = Console.ReadLine();

            while (input != "stop")
            {
                int currentNum = int.Parse(input);

                if (currentNum < 0)
                {
                    Console.WriteLine($"Number is negative.");
                    input = Console.ReadLine();
                    continue;
                }

                bool isNotPrime = false;
                for (int i = 2; i < currentNum; i++)
                {
                    if (currentNum % i == 0)
                    {
                        isNotPrime = true;
                        break;
                    }
                }
                if (isNotPrime)
                {
                    nonPrimeSum += currentNum;
                }
                else
                {
                    primeSum += currentNum;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");

            //04. Train The Trainers
            int n = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double gradeSum = 0;
            double averageGrade = 0;
            double sumOfAllPresentations = 0;
            double averageOfAllGrades = 0;
            int presentationCount = 0;

            while (presentationName != "Finish")
            {
                for (int i = 0; i < n; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradeSum += grade;
                    averageGrade = gradeSum / n;
                }
                gradeSum = 0;

                Console.WriteLine($"{presentationName} - {averageGrade:F2}.");
                sumOfAllPresentations += averageGrade;
                presentationCount++;
                averageOfAllGrades = sumOfAllPresentations / presentationCount;
                presentationName = Console.ReadLine();


            }
            Console.WriteLine($"Student's final assessment is {averageOfAllGrades:F2}.");

            //05. Special Numbers
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                int currentNum = i;
                bool isSpecial = true;
                for (int j = 0; j < 4; j++)
                {
                    int digit = currentNum % 10;
                    if (digit == 0 || n % digit != 0)
                    {
                        isSpecial = false;
                        break;
                    }
                    currentNum /= 10;

                }
                if (isSpecial)
                {
                    Console.Write($"{i} ");
                }
            }

            //06. Cinema Tickets
            int totalCount = 0, standardCount = 0, kidsCount = 0, studentsCount = 0;
            string movieName = Console.ReadLine();



            while (movieName != "Finish")
            {
                int places = int.Parse(Console.ReadLine());
                int currentTickets = 0;
                for (int i = 0; i < places; i++)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }
                    switch (ticketType)
                    {
                        case "standard":
                            standardCount++;
                            break;
                        case "student":
                            studentsCount++;
                            break;
                        case "kid":
                            kidsCount++;
                            break;
                    }
                    currentTickets++;
                }
                totalCount += currentTickets;
                double percentage = (double)currentTickets / places * 100;
                Console.WriteLine($"{movieName} - {percentage:F2}% full.");

                movieName = Console.ReadLine();
            }
            double percentageStudents = (double)studentsCount / totalCount * 100;
            double percentageStandard = (double)standardCount / totalCount * 100;
            double percentageKids = (double)kidsCount / totalCount * 100;

            Console.WriteLine($"Total tickets: {totalCount}");
            Console.WriteLine($"{percentageStudents:F2}% student tickets.");
            Console.WriteLine($"{percentageStandard:F2}% standard tickets.");
            Console.WriteLine($"{percentageKids:F2}% kids tickets.");
        }
    }
}