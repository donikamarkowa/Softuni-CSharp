namespace Exercise
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            //01. Cinema
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            double income = 0.0;
            if (projection == "Premiere")
            {
                income = rows * columns * 12.00;
            }
            else if (projection == "Normal")
            {
                income = rows * columns * 7.50;
            }
            else if (projection == "Discount")
            {
                income = rows * columns * 5.00;
            }
            Console.WriteLine($"{income:F2} leva");

            //02. Summer Outfit
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            if (degrees >= 10 && degrees <= 18)
            {
                switch (timeOfDay)
                {
                    case "Morning":
                        Console.WriteLine($"It's {degrees} degrees, get your Sweatshirt and Sneakers.");
                        break;
                    case "Afternoon":
                    case "Evening":
                        Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                        break;
                }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                switch (timeOfDay)
                {
                    case "Morning":
                    case "Evening":
                        Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                        break;
                    case "Afternoon":
                        Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals.");
                        break;


                }
            }
            else if (degrees >= 25)
            {
                switch (timeOfDay)
                {
                    case "Morning":
                        Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals.");
                        break;
                    case "Afternoon":
                        Console.WriteLine($"It's {degrees} degrees, get your Swim Suit and Barefoot.");
                        break;
                    case "Evening":
                        Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");
                        break;
                }
            }

            //03. New House
            string kindOfFlowers = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double remainderSum = 0;
            if (kindOfFlowers == "Roses")
            {
                if (numFlowers > 80)
                {
                    remainderSum = budget - ((numFlowers * 5) - (0.10 * (numFlowers * 5)));
                }
                else
                {
                    remainderSum = budget - (numFlowers * 5);
                }
            }
            else if (kindOfFlowers == "Dahlias")
            {
                if (numFlowers > 90)
                {
                    remainderSum = budget - ((numFlowers * 3.80) - (0.15 * (numFlowers * 3.80)));
                }
                else
                {
                    remainderSum = budget - (numFlowers * 3.80);
                }
            }
            else if (kindOfFlowers == "Tulips")
            {
                if (numFlowers > 80)
                {
                    remainderSum = budget - ((numFlowers * 2.80) - (0.15 * (numFlowers * 2.80)));
                }
                else
                {
                    remainderSum = budget - (numFlowers * 2.80);
                }
            }
            else if (kindOfFlowers == "Narcissus")
            {

                if (numFlowers < 120)
                {
                    remainderSum = budget - ((numFlowers * 3) + (0.15 * (numFlowers * 3)));
                }
                else
                {
                    remainderSum = budget - (numFlowers * 3);
                }
            }
            else
            {
                if (numFlowers < 80)
                {
                    remainderSum = budget - ((numFlowers * 2.50) + (0.20 * (numFlowers * 2.50)));
                }
                else
                {
                    remainderSum = budget - (numFlowers * 2.50);
                }
            }
            if (remainderSum >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {kindOfFlowers} and {remainderSum:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(remainderSum):F2} leva more.");
            }


            //04. Fishing Boat
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());
            double priceForRent = 0.0;
            switch (season)
            {
                case "Spring":
                    priceForRent += 3000;
                    {
                        if (fishermen <= 6)
                        {
                            double newpriceForRent = priceForRent - priceForRent * 0.1;
                            if (fishermen % 2 == 0)
                            {
                                newpriceForRent = newpriceForRent - newpriceForRent * 0.05;
                            }
                            if (budget >= newpriceForRent)
                            {
                                double leftMoney = budget - newpriceForRent;
                                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
                            }
                            else
                            {

                                double neededMoney = newpriceForRent - budget;
                                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                            }

                        }
                        else if (fishermen >= 7 && fishermen <= 11)
                        {
                            double newpriceForRent = priceForRent - priceForRent * 0.15;
                            if (fishermen % 2 == 0)
                            {
                                newpriceForRent = newpriceForRent - newpriceForRent * 0.05;
                            }
                            if (budget >= newpriceForRent)
                            {
                                double leftMoney = budget - newpriceForRent;
                                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
                            }
                            else
                            {

                                double neededMoney = newpriceForRent - budget;
                                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                            }
                        }
                        else if (fishermen >= 12)
                        {
                            double newpriceForRent = priceForRent - priceForRent * 0.25;
                            if (fishermen % 2 == 0)
                            {
                                newpriceForRent = newpriceForRent - newpriceForRent * 0.05;
                            }
                            if (budget >= newpriceForRent)
                            {
                                double leftMoney = budget - newpriceForRent;
                                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
                            }
                            else
                            {

                                double neededMoney = newpriceForRent - budget;
                                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                            }
                        }
                    }
                    break;
                case "Summer":
                case "Autumn":
                    priceForRent += 4200;
                    {
                        if (fishermen <= 6)
                        {
                            double newpriceForRent = priceForRent - priceForRent * 0.1;

                            if (budget >= newpriceForRent)
                            {

                                double leftMoney = budget - newpriceForRent;
                                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
                            }
                            else
                            {

                                double neededMoney = newpriceForRent - budget;
                                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                            }

                        }
                        else if (fishermen >= 7 && fishermen <= 11)
                        {
                            double newpriceForRent = priceForRent - priceForRent * 0.15;
                            if (fishermen % 2 == 0)
                            {
                                newpriceForRent = newpriceForRent - newpriceForRent * 0.05;
                            }
                            if (budget >= newpriceForRent)
                            {
                                double leftMoney = budget - newpriceForRent;
                                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
                            }
                            else
                            {

                                double neededMoney = newpriceForRent - budget;
                                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                            }
                        }
                        else if (fishermen >= 12)
                        {
                            double newpriceForRent = priceForRent - priceForRent * 0.25;
                            if (fishermen % 2 == 0)
                            {
                                newpriceForRent = newpriceForRent - newpriceForRent * 0.05;
                            }
                            if (budget >= newpriceForRent)
                            {
                                double leftMoney = budget - newpriceForRent;
                                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
                            }
                            else
                            {

                                double neededMoney = newpriceForRent - budget;
                                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                            }
                        }
                    }
                    break;
                case "Winter":
                    priceForRent += 2600;
                    {
                        if (fishermen <= 6)
                        {
                            double newpriceForRent = priceForRent - priceForRent * 0.1;
                            if (fishermen % 2 == 0)
                            {
                                newpriceForRent = newpriceForRent - newpriceForRent * 0.05;
                            }
                            if (budget >= newpriceForRent)
                            {
                                double leftMoney = budget - newpriceForRent;
                                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
                            }
                            else
                            {

                                double neededMoney = newpriceForRent - budget;
                                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                            }

                        }
                        else if (fishermen >= 7 && fishermen <= 11)
                        {
                            double newpriceForRent = priceForRent - priceForRent * 0.15;
                            if (fishermen % 2 == 0)
                            {
                                newpriceForRent = newpriceForRent - newpriceForRent * 0.05;
                            }
                            if (budget >= newpriceForRent)
                            {
                                double leftMoney = budget - newpriceForRent;
                                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
                            }
                            else
                            {

                                double neededMoney = newpriceForRent - budget;
                                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                            }
                        }
                        else if (fishermen >= 12)
                        {
                            double newpriceForRent = priceForRent - priceForRent * 0.25;
                            if (fishermen % 2 == 0)
                            {
                                newpriceForRent = newpriceForRent - newpriceForRent * 0.05;
                            }
                            if (budget >= newpriceForRent)
                            {
                                double leftMoney = budget - newpriceForRent;
                                Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
                            }
                            else
                            {

                                double neededMoney = newpriceForRent - budget;
                                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                            }
                        }
                    }
                    break;
            }

            //05. Journey
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            if (budget <= 100)
            {
                if (season == "summer")
                {
                    double spentMoney = budget * 0.3;
                    Console.WriteLine($"Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {spentMoney:F2}");
                }
                else if (season == "winter")
                {
                    double spentMoney = budget * 0.7;
                    Console.WriteLine($"Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {spentMoney:F2}");
                }
            }
            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    double spentMoney = budget * 0.4;
                    Console.WriteLine($"Somewhere in Balkans");
                    Console.WriteLine($"Camp - {spentMoney:F2}");
                }
                else if (season == "winter")
                {
                    double spentMoney = budget * 0.8;
                    Console.WriteLine($"Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {spentMoney:F2}");
                }
            }
            else if (budget > 1000)
            {
                switch (season)
                {
                    case "summer":
                    case "winter":
                        double spentMoney = budget * 0.9;
                        Console.WriteLine($"Somewhere in Europe");
                        Console.WriteLine($"Hotel - {spentMoney:F2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;

                }
            }

            //06. Operations Between Numbers
            double num1 = int.Parse(Console.ReadLine());
            double num2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            if (operation == '+')
            {
                double sum = num1 + num2;
                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{num1} + {num2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} + {num2} = {sum} - odd");
                }
            }
            else if (operation == '-')
            {
                double difference = num1 - num2;
                if (difference % 2 == 0)
                {
                    Console.WriteLine($"{num1} - {num2} = {difference} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} - {num2} = {difference} - odd");
                }
            }
            else if (operation == '*')
            {
                double product = num1 * num2;
                if (product % 2 == 0)
                {
                    Console.WriteLine($"{num1} * {num2} = {product} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} * {num2} = {product} - odd");
                }
            }
            else if (operation == '/')
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    double division = num1 / num2;
                    Console.WriteLine($"{num1} / {num2} = {division:F2}");
                }
            }
            else if (operation == '%')
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {

                    double divisionWithQuotien = num1 % num2;
                    Console.WriteLine($"{num1} % {num2} = {divisionWithQuotien}");
                }
            }

            //08. On Time for the Exam
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMin = int.Parse(Console.ReadLine());
            int examTime = examHour * 60 + examMin;
            int arriveTime = arriveHour * 60 + arriveMin;
            int diff = examTime - arriveTime;
            if (diff > 30)
            {
                Console.WriteLine("Early");
            }
            else if (diff >= 0 && diff <= 30)
            {
                Console.WriteLine("On time");
            }
            else
            {
                Console.WriteLine("Late");
            }
            if (diff < 60 && diff > 0)
            {
                Console.WriteLine($"{diff} minutes before the start");
            }
            else if (diff >= 60)
            {
                int resultHour = diff / 60;
                int resultMin = diff % 60;
                if (resultMin >= 10)
                {
                    Console.WriteLine($"{resultHour}:{resultMin} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{resultHour}:0{resultMin} hours before the start");
                }
            }
            else if (diff > -60 && diff < 0)
            {
                Console.WriteLine($"{Math.Abs(diff)} minutes after the start");
            }
            else if (diff <= 60)
            {
                int resultHour = Math.Abs(diff) / 60;
                int resultMin = Math.Abs(diff) % 60;
                if (resultMin >= 10)
                {
                    Console.WriteLine($"{resultHour}:{resultMin} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{resultHour}:0{resultMin} hours after the start");
                }
            }

            //09. Ski Trip
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rating = Console.ReadLine();
            switch (room)
            {
                case "room for one person":
                    double moneyForRoom = (days - 1) * 18;
                    if (rating == "positive")
                    {
                        moneyForRoom = moneyForRoom + moneyForRoom * 0.25;
                        Console.WriteLine("{0:F2}", moneyForRoom);
                    }
                    else if (rating == "negative")
                    {
                        moneyForRoom = moneyForRoom - moneyForRoom * 0.1;
                        Console.WriteLine("{0:F2}", moneyForRoom);
                    }
                    break;
                case "apartment":
                    double moneyForApartment = (days - 1) * 25;
                    if (days < 10)
                    {
                        moneyForApartment = moneyForApartment - moneyForApartment * 0.3;
                        if (rating == "positive")
                        {
                            moneyForApartment = moneyForApartment + moneyForApartment * 0.25;
                            Console.WriteLine("{0:F2}", moneyForApartment);
                        }
                        else if (rating == "negative")
                        {
                            moneyForApartment = moneyForApartment - moneyForApartment * 0.1;
                            Console.WriteLine("{0:F2}", moneyForApartment);
                        }
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        moneyForApartment = moneyForApartment - moneyForApartment * 0.35;
                        if (rating == "positive")
                        {
                            moneyForApartment = moneyForApartment + moneyForApartment * 0.25;
                            Console.WriteLine("{0:F2}", moneyForApartment);
                        }
                        else if (rating == "negative")
                        {
                            moneyForApartment = moneyForApartment - moneyForApartment * 0.1;
                            Console.WriteLine("{0:F2}", moneyForApartment);
                        }
                    }
                    else if (days > 15)
                    {
                        moneyForApartment = moneyForApartment - moneyForApartment * 0.5;
                        if (rating == "positive")
                        {
                            moneyForApartment = moneyForApartment + moneyForApartment * 0.25;
                            Console.WriteLine("{0:F2}", moneyForApartment);
                        }
                        else if (rating == "negative")
                        {
                            moneyForApartment = moneyForApartment - moneyForApartment * 0.1;
                            Console.WriteLine("{0:F2}", moneyForApartment);
                        }
                    }
                    break;
                case "president apartment":
                    double moneyForPresidentApartment = (days - 1) * 35;
                    if (days < 10)
                    {
                        moneyForPresidentApartment = moneyForPresidentApartment - moneyForPresidentApartment * 0.1;
                        if (rating == "positive")
                        {
                            moneyForPresidentApartment = moneyForPresidentApartment + moneyForPresidentApartment * 0.25;
                            Console.WriteLine("{0:F2}", moneyForPresidentApartment);
                        }
                        else if (rating == "negative")
                        {
                            moneyForPresidentApartment = moneyForPresidentApartment - moneyForPresidentApartment * 0.1;
                            Console.WriteLine("{0:F2}", moneyForPresidentApartment);
                        }
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        moneyForPresidentApartment = moneyForPresidentApartment - moneyForPresidentApartment * 0.15;
                        if (rating == "positive")
                        {
                            moneyForPresidentApartment = moneyForPresidentApartment + moneyForPresidentApartment * 0.25;
                            Console.WriteLine("{0:F2}", moneyForPresidentApartment);
                        }
                        else if (rating == "negative")
                        {
                            moneyForPresidentApartment = moneyForPresidentApartment - moneyForPresidentApartment * 0.1;
                            Console.WriteLine("{0:F2}", moneyForPresidentApartment);
                        }
                    }
                    else if (days > 15)
                    {
                        moneyForPresidentApartment = moneyForPresidentApartment - moneyForPresidentApartment * 0.2;
                        if (rating == "positive")
                        {
                            moneyForPresidentApartment = moneyForPresidentApartment + moneyForPresidentApartment * 0.25;
                            Console.WriteLine("{0:F2}", moneyForPresidentApartment);
                        }
                        else if (rating == "negative")
                        {
                            moneyForPresidentApartment = moneyForPresidentApartment - moneyForPresidentApartment * 0.1;
                            Console.WriteLine("{0:F2}", moneyForPresidentApartment);
                        }
                    }
                    break;
            }

        }
    }
}