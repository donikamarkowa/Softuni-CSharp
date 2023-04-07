namespace Lab
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            //01. Read Text
            while (true)
            {
                string word = Console.ReadLine();
                if (word == "Stop")
                {
                    break;
                }
                Console.WriteLine(word);
            }

            //02. Password
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != password)
            {
                input = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {username}!");

            //03. Sum Numbers
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            while (number > sum)
            {
                int currentNum = int.Parse(Console.ReadLine());
                sum += currentNum;
            }
            Console.WriteLine(sum);

            //04. Sequence 2k+1
            int number = int.Parse(Console.ReadLine());
            int k = 1;
            while (k <= number)
            {
                Console.WriteLine(k);
                k = k * 2 + 1;
            }

            //05. Account Balance
            string input = Console.ReadLine();
            double sum = 0.0;

            while (input != "NoMoreMoney")
            {
                double money = double.Parse(input);
                if (money < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                sum += money;
                Console.WriteLine($"Increase: {money:F2}");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {sum:F2} ");

            //06. Max Number
            string input = Console.ReadLine();
            int maxNum = int.MinValue;

            while (input != "Stop")
            {
                int num = int.Parse(input);
                if (num > maxNum)
                {
                    maxNum = num;
                }
                input = Console.ReadLine();


            }
            Console.WriteLine(maxNum);

            //07. Min Number
            string input = Console.ReadLine();
            int minNum = int.MaxValue;

            while (input != "Stop")
            {
                int num = int.Parse(input);
                if (num < minNum)
                {
                    minNum = num;
                }
                input = Console.ReadLine();


            }
            Console.WriteLine(minNum);


            //08. Graduation
            string studentName = Console.ReadLine();
            int grades = 1;
            double currentGrade = 0;
            double gradesSum = 0;
            bool graduated = true;
            int failCounter = 0;

            while (grades <= 12)
            {
                currentGrade = double.Parse(Console.ReadLine());
                if (currentGrade < 4)
                {
                    failCounter++;
                    if (failCounter > 1)
                    {
                        Console.WriteLine($"{studentName} has been excluded at {grades} grade");
                        graduated = false;
                        break;
                    }
                    continue;
                }
                gradesSum += currentGrade;
                grades++;
            }

            if (graduated)
            {
                Console.WriteLine($"{studentName} graduated. Average grade: {(gradesSum / 12):F2}");
            }
        }
    }
}