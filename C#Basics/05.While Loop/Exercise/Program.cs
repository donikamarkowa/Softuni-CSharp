namespace Exercise
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            //01. Old Books
            string nameBook = Console.ReadLine();
            int numberOfBooks = 0;

            while (nameBook != "No More Books")
            {
                string searchedBook = Console.ReadLine();

                if (searchedBook == nameBook)
                {
                    Console.WriteLine($"You checked {numberOfBooks} books and found it.");
                    break;
                }

                if (searchedBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {numberOfBooks} books.");
                    break;
                }
                numberOfBooks++;
            }

            //02. Exam Preparation
            int failedGrades = int.Parse(Console.ReadLine());
            int failedTimes = 0;
            int solvedProblemsCount = 0;
            double gradesSum = 0;
            string lastProblem = "";
            bool isFailed = true;

            while (failedTimes < failedGrades)
            {
                string problemName = Console.ReadLine();
                if (problemName == "Enough")
                {
                    isFailed = false;
                    break;
                }

                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    failedTimes++;
                }
                gradesSum += grade;
                solvedProblemsCount++;
                lastProblem = problemName;
            }
            if (isFailed)
            {
                Console.WriteLine($"You need a break, {failedGrades} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {(gradesSum / solvedProblemsCount):F2}");
                Console.WriteLine($"Number of problems: {solvedProblemsCount}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }

            //03. Vacation
            double moneyNeededForVacantion = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());
            int daysCounter = 0;
            int spendingCounter = 0;

            while (currentMoney < moneyNeededForVacantion && spendingCounter < 5)
            {
                string action = Console.ReadLine();
                double moneyFromAction = double.Parse(Console.ReadLine());
                daysCounter++;
                if (action == "save")
                {
                    currentMoney += moneyFromAction;
                    //daysCounter -= 1;
                    spendingCounter = 0;
                }
                else
                {
                    currentMoney -= moneyFromAction;
                    spendingCounter++;
                    //daysCounter++;

                    if (currentMoney < 0)
                    {
                        currentMoney = 0;
                    }
                }
            }
            if (spendingCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCounter);
            }
            if (currentMoney >= moneyNeededForVacantion)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }

            //04. Walking
            string steps = Console.ReadLine();
            int countSteps = 0;
            while (steps != "Going home")
            {

                int stepsNumber = int.Parse(steps);
                countSteps += stepsNumber;
                if (countSteps >= 10000)
                {
                    int moreSteps = countSteps - 10000;
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{moreSteps} steps over the goal!");
                    return;
                }
                steps = Console.ReadLine();
            }
            if (steps == "Going home")
            {
                int stepsToHome = int.Parse(Console.ReadLine());
                countSteps += stepsToHome;
                if (countSteps >= 10000)
                {
                    int moreSteps = countSteps - 10000;
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{moreSteps} steps over the goal!");
                    return;
                }

                if (countSteps < 10000)
                {
                    int neededSteps = 10000 - countSteps;
                    Console.WriteLine($"{neededSteps} more steps to reach goal.");
                }

            }

            //05. Coins
            double change = double.Parse(Console.ReadLine());
            change = Math.Round(change, 2);
            int coins = 0;

            while (change > 0)
            {
                if (change >= 2.00)
                {
                    change -= 2.00;
                    change = Math.Round(change, 2);
                    coins++;
                    continue;
                }
                else if (change >= 1.00)
                {
                    change -= 1.0;
                    change = Math.Round(change, 2);
                    coins++;
                    continue;
                }
                else if (change >= 0.5)
                {
                    change -= 0.5;
                    change = Math.Round(change, 2);
                    coins++;
                    continue;
                }
                else if (change >= 0.2)
                {
                    change -= 0.2;
                    change = Math.Round(change, 2);
                    coins++;
                    continue;
                }
                else if (change >= 0.1)
                {
                    change -= 0.1;
                    change = Math.Round(change, 2);
                    coins++;
                    continue;
                }
                else if (change >= 0.05)
                {
                    change -= 0.05;
                    change = Math.Round(change, 2);
                    coins++;
                    continue;
                }
                else if (change >= 0.02)
                {
                    change -= 0.02;
                    change = Math.Round(change, 2);
                    coins++;
                    continue;
                }
                else if (change >= 0.01)
                {
                    change -= 0.01;
                    change = Math.Round(change, 2);
                    coins++;
                }
            }
            Console.WriteLine(coins);

            //06. Cake
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int piecesCount = width * length;
            string piecesTaken = Console.ReadLine();

            while (piecesTaken != "STOP")
            {
                int piecesNumber = int.Parse(piecesTaken);
                piecesCount -= piecesNumber;
                if (piecesCount < 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(piecesCount)} pieces more.");
                    return;
                }
                piecesTaken = Console.ReadLine();

            }
            Console.WriteLine($"{piecesCount} pieces are left.");

            //07. Moving
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int sizeBox = width * length * height;
            string boxes = Console.ReadLine();

            while (boxes != "Done")
            {
                int boxesMetres = int.Parse(boxes);
                sizeBox -= boxesMetres;
                if (sizeBox < 0)
                {

                    Console.WriteLine($"No more free space! You need {Math.Abs(sizeBox)} Cubic meters more.");
                    return;
                }
                boxes = Console.ReadLine();

            }
            Console.WriteLine($"{sizeBox} Cubic meters left.");
        }
    }
}