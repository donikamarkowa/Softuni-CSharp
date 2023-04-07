namespace Exercise
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            //01. Sum Seconds
            int seconds1 = int.Parse(Console.ReadLine());
            int seconds2 = int.Parse(Console.ReadLine());
            int seconds3 = int.Parse(Console.ReadLine());
            int allSeconds = seconds1 + seconds2 + seconds3;
            int minutes = allSeconds / 60;
            int seconds = allSeconds % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }

            //02. Bonus Score
            int number = int.Parse(Console.ReadLine());
            double bonus = 0.0;
            if (number <= 100)
            {
                bonus = 5;
            }
            else if (number > 1000)
            {
                bonus = number * 0.1;
            }
            else
            {
                bonus = number * 0.2;
            }
            if (number % 2 == 0)
            {
                bonus += 1;
            }
            else if (number % 10 == 5)
            {
                bonus += 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(number + bonus);

            //03. Time + 15 Minutes
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());

            min += 15;

            if (min >= 60)
            {
                min = min - 60;
                hour = hour + 1;
            }

            if (hour > 23)
            {
                hour = 0;
            }

            if (min >= 10)
            {
                Console.WriteLine($"{hour}:{min}");
            }
            else
            {
                Console.WriteLine($"{hour}:0{min}");
            }

            //04. Toy Shop
            double moneyForVacation = double.Parse(Console.ReadLine());
            int pizzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());
            double moneyPuzzles = pizzles * 2.60;
            double moneyDolls = dolls * 3;
            double moneyBears = bears * 4.10;
            double moneyMinions = minions * 8.20;
            double moneyTrucks = trucks * 2;
            int allToys = pizzles + dolls + bears + minions + trucks;
            double allMoneyForToys = moneyPuzzles + moneyDolls + moneyBears + moneyMinions + moneyTrucks;
            if (allToys >= 50)
            {
                allMoneyForToys = allMoneyForToys - allMoneyForToys * 0.25;
            }
            double moneyForRent = allMoneyForToys * 0.1;
            double wonMoney = allMoneyForToys - moneyForRent;
            double leftMoney;
            double notEnoughMoney;
            if (wonMoney >= moneyForVacation)
            {
                leftMoney = wonMoney - moneyForVacation;
                Console.WriteLine($"Yes! {leftMoney:f2} lv left.");
            }
            else if (wonMoney <= moneyForVacation)

            {
                notEnoughMoney = moneyForVacation - wonMoney;
                Console.WriteLine($"Not enough money! {notEnoughMoney:f2} lv needed.");
            }

            //05. Godzilla vs. Kong
            double buget = double.Parse(Console.ReadLine());
            int PeopleCount = int.Parse(Console.ReadLine());
            double SinglePrice = double.Parse(Console.ReadLine());
            double bugetNeeded = buget * 0.1;

            if (PeopleCount > 150)
            {
                bugetNeeded += PeopleCount * SinglePrice * 0.9;

            }

            else
            {
                bugetNeeded += PeopleCount * SinglePrice;
            }

            if (bugetNeeded > buget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {bugetNeeded - buget:F2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {buget - bugetNeeded:F2} leva left.");
            }

            //06. World Swimming Record
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double secondsForOneMeter = double.Parse(Console.ReadLine());
            double seconds = distanceInMeters * secondsForOneMeter;
            double addedSeconds = Math.Floor(distanceInMeters / 15) * 12.5;
            double fullTime = seconds + addedSeconds;
            if (recordInSeconds > fullTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {fullTime:f2} seconds.");
            }
            else if (recordInSeconds <= fullTime)
            {
                double neededSeconds = fullTime - recordInSeconds;
                Console.WriteLine($"No, he failed! He was {neededSeconds:f2} seconds slower.");
            }

            //07. Shopping
            double budget = double.Parse(Console.ReadLine());
            int videoCards = int.Parse(Console.ReadLine());
            int processors = int.Parse(Console.ReadLine());
            int ramMemory = int.Parse(Console.ReadLine());
            double priceVideoCards = videoCards * 250;
            double priceProcessors = (priceVideoCards * 0.35) * processors;
            double priceRamMemory = (priceVideoCards * 0.1) * ramMemory;
            double allMoney = priceVideoCards + priceProcessors + priceRamMemory;
            if (videoCards > processors)
            {
                allMoney = allMoney - allMoney * 0.15;
            }
            if (budget >= allMoney)
            {
                double leftMoney = budget - allMoney;

                Console.WriteLine($"You have {leftMoney:f2} leva left!");
            }
            else if (budget <= allMoney)
            {
                double neededMoney = allMoney - budget;
                Console.WriteLine($"Not enough money! You need {neededMoney:f2} leva more!");
            }

            //08. Lunch Break
            string nameOfSeries = Console.ReadLine();
            double timeOfSeries = double.Parse(Console.ReadLine());
            double timeForBreak = double.Parse(Console.ReadLine());
            double timeForLunch = timeForBreak / 8;
            double timeForRest = timeForBreak / 4;
            double timeLeft = timeForBreak - (timeForLunch + timeForRest);
            if (timeLeft >= timeOfSeries)
            {
                double freeTime = Math.Ceiling(timeLeft - timeOfSeries);
                Console.WriteLine($"You have enough time to watch {nameOfSeries} and left with {freeTime} minutes free time.");
            }
            else if (timeLeft < timeOfSeries)
            {
                double neededTime = Math.Ceiling(timeOfSeries - timeLeft);

                Console.WriteLine($"You don't have enough time to watch {nameOfSeries}, you need {neededTime} more minutes.");
            }
        }
    }
}