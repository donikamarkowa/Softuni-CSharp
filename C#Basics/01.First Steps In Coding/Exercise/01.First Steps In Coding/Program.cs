namespace _01.First_Steps_In_Coding
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            //01. USD to BGN
            double usd = double.Parse(Console.ReadLine());
            double bgn = usd * 1.79549;
            Console.WriteLine(bgn);

            //02. Radians to Degrees
            double radians = double.Parse(Console.ReadLine());
            double degrees = (radians * 180) / Math.PI;
            Console.WriteLine(degrees);

            //03. Deposit Calculator
            double depSum = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double sum = depSum + months * ((depSum * percent / 100) / 12);
            Console.WriteLine(sum);

            //04. Vacation Books List
            int pages = int.Parse(Console.ReadLine());
            int pagesForOneHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int hours = pages / pagesForOneHour;
            int hoursForOneDay = hours / days;
            Console.WriteLine(hoursForOneDay);

            //05. Supplies for School
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int preparation = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());
            double pricePens = pens * 5.80;
            double priceMarkers = markers * 7.20;
            double pricePreparation = preparation * 1.20;
            double fullPrice = pricePens + priceMarkers + pricePreparation;
            double fullPriceWithDiscount = fullPrice - (fullPrice * discount / 100);
            Console.WriteLine(fullPriceWithDiscount);

            //06. Repainting
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int thinner = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double priceNylon = (nylon + 2) * 1.50;
            double pricePaint = (paint + 0.1 * paint) * 14.50;
            double priceThinner = thinner * 5.00;
            double priceBags = 0.40;
            double priceAllMaterials = priceNylon + pricePaint + priceThinner + priceBags;
            double priceWorkers = (priceAllMaterials * 0.3) * hours;
            double finalPrice = priceAllMaterials + priceWorkers;
            Console.WriteLine(finalPrice);

            //07. Food Delivery
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegMenu = int.Parse(Console.ReadLine());
            double priceChickenMenu = chickenMenu * 10.35;
            double priceFishMenu = fishMenu * 12.40;
            double priceVegMenu = vegMenu * 8.15;
            double fullPrice = priceChickenMenu + priceFishMenu + priceVegMenu;
            double priceDessert = fullPrice * 0.2;
            double priceDelivery = 2.50;
            double priceForAll = fullPrice + priceDessert + priceDelivery;
            Console.WriteLine(priceForAll);

            //08. Basketball Equipment
            int priceBasketball = int.Parse(Console.ReadLine());
            double shoes = priceBasketball - priceBasketball * 0.4;
            double outfit = shoes - shoes * 0.2;
            double ball = outfit / 4;
            double accessories = ball / 5;
            double finalPrice = priceBasketball + shoes + outfit + ball + accessories;
            Console.WriteLine(finalPrice);

            //09. Fish Tank
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double volume = length * width * height;
            double volumeInLiters = volume / 1000;
            double neededLiters = volumeInLiters * (1 - percent / 100);
            Console.WriteLine(neededLiters);



        }
    }
}