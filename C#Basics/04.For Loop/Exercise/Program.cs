namespace Exercise
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            //01. Numbers Ending in 7
            for (int i = 0; i < 1000; i++)
            {
                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }

            //02. Half Sum Element
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (num > max)
                {
                    max = num;
                }

            }
            int sumWithoutMax = sum - max;
            if (sumWithoutMax == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + sumWithoutMax);
            }
            else
            {
                int diff = Math.Abs(max - sumWithoutMax);
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }

            //03. Histogram
            int p1Number = 0, p2Number = 0, p3Number = 0, p4Number = 0, p5Number = 0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    p1Number++;
                }
                else if (num < 400)
                {
                    p2Number++;
                }
                else if (num < 600)
                {
                    p3Number++;
                }
                else if (num < 800)
                {
                    p4Number++;
                }
                else
                {
                    p5Number++;
                }
            }
            double p1Percentage = 0, p2Percentage = 0, p3Percentage = 0, p4Percentage = 0, p5Percentage = 0;
            p1Percentage = (double)p1Number / n * 100;
            p2Percentage = (double)p2Number / n * 100;
            p3Percentage = (double)p3Number / n * 100;
            p4Percentage = (double)p4Number / n * 100;
            p5Percentage = (double)p5Number / n * 100;
            Console.WriteLine($"{p1Percentage:F2}%");
            Console.WriteLine($"{p2Percentage:F2}%");
            Console.WriteLine($"{p3Percentage:F2}%");
            Console.WriteLine($"{p4Percentage:F2}%");
            Console.WriteLine($"{p5Percentage:F2}%");

            //04. Clever Lily
            int age = int.Parse(Console.ReadLine());
            double priceWashingMachine = double.Parse(Console.ReadLine());
            double priceToy = double.Parse(Console.ReadLine());
            int toys = 0;
            double money = 0.0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money += (i * 10 / 2) - 1;


                }
                else
                {
                    toys++;
                }
            }

            double soldToysPrice = toys * priceToy;
            double savedMoney = soldToysPrice + money;

            if (savedMoney < priceWashingMachine)
            {
                double neededMoney = Math.Abs(priceWashingMachine - savedMoney);
                Console.WriteLine($"No! {neededMoney:F2}");
            }
            else
            {
                double leftMoney = savedMoney - priceWashingMachine;
                Console.WriteLine($"Yes! {leftMoney:F2} ");
            }

            //05. Salary
            int countTabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int i = 1; i <= countTabs; i++)
            {
                string website = Console.ReadLine();

                if (website == "Facebook")
                {
                    salary -= 150;

                }
                else if (website == "Instagram")
                {
                    salary -= 100;
                }
                else if (website == "Reddit")
                {
                    salary -= 50;
                }
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else if (salary > 0)
            {
                Console.WriteLine(salary);
            }

            //06. Oscars
            string nameActor = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int countRatePeople = int.Parse(Console.ReadLine());

            double finalPoints = 0.0;
            for (int i = 1; i <= countRatePeople; i++)
            {
                string nameRatePerson = Console.ReadLine();

                double pointsFromRatePerson = double.Parse(Console.ReadLine());
                double points = (nameRatePerson.Length * pointsFromRatePerson) / 2;
                finalPoints += points;
                if (finalPoints + pointsFromAcademy >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {(finalPoints + pointsFromAcademy):F1}! ");
                    break;
                }
            }

            if (finalPoints + pointsFromAcademy < 1250.5)
            {
                double neededPoints = 1250.5 - (finalPoints + pointsFromAcademy);
                Console.WriteLine($"Sorry, {nameActor} you need {neededPoints:F1} more! ");
            }

            //07. Trekking Mania
            int peopleMusala = 0, peopleMonblan = 0, peopleKilimandjaro = 0, peopleK2 = 0, peopleEverest = 0;
            int groupCount = int.Parse(Console.ReadLine());
            int totalPeopleCount = 0;
            for (int i = 0; i < groupCount; i++)
            {
                int peopleCount = int.Parse(Console.ReadLine());
                totalPeopleCount += peopleCount;

                if (peopleCount <= 5)
                {
                    peopleMusala += peopleCount;
                }
                else if (peopleCount >= 6 && peopleCount <= 12)
                {
                    peopleMonblan += peopleCount;
                }
                else if (peopleCount >= 13 && peopleCount <= 25)
                {
                    peopleKilimandjaro += peopleCount;
                }
                else if (peopleCount >= 26 && peopleCount <= 40)
                {
                    peopleK2 += peopleCount;
                }
                else if (peopleCount >= 41)
                {
                    peopleEverest += peopleCount;
                }

            }
            double percentageMusala, percentageMonblan, percentageKilimandjaro, percentageK2, percentageEverest;
            percentageMusala = (double)peopleMusala / totalPeopleCount * 100;
            percentageMonblan = (double)peopleMonblan / totalPeopleCount * 100;
            percentageKilimandjaro = (double)peopleKilimandjaro / totalPeopleCount * 100;

            percentageK2 = (double)peopleK2 / totalPeopleCount * 100;
            percentageEverest = (double)peopleEverest / totalPeopleCount * 100;

            Console.WriteLine($"{percentageMusala:F2}%");
            Console.WriteLine($"{percentageMonblan:F2}%");
            Console.WriteLine($"{percentageKilimandjaro:F2}%");
            Console.WriteLine($"{percentageK2:F2}%");
            Console.WriteLine($"{percentageEverest:F2}%");

            //08. Tennis Ranklist
            int tournaments = int.Parse(Console.ReadLine());
            double startingPoints = double.Parse(Console.ReadLine());
            double winTournaments = 0.0;
            double winPointsForTournament = 0.0;
            for (int i = 1; i <= tournaments; i++)
            {
                string finishRace = Console.ReadLine();
                if (finishRace == "W")
                {
                    startingPoints += 2000;
                    winPointsForTournament += 2000;
                    winTournaments++;
                }
                else if (finishRace == "F")
                {
                    startingPoints += 1200;
                    winPointsForTournament += 1200;
                }
                else if (finishRace == "SF")
                {
                    startingPoints += 720;
                    winPointsForTournament += 720;
                }
            }
            double leftPoints = startingPoints - startingPoints;
            int averagePoints = (int)(winPointsForTournament / tournaments);
            double percentWinTournaments = (winTournaments / tournaments) * 100;
            Console.WriteLine($"Final points: {startingPoints} ");
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{percentWinTournaments:F2}%");



        }
    }
}