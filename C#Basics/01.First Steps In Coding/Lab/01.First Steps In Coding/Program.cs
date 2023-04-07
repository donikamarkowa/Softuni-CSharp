namespace _01.First_Steps_In_Coding
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            //01. Hello SoftUni
            Console.WriteLine("Hello SoftUni");

            //02. Nums 1...10
            Console.WriteLine(1);
            Console.WriteLine(2);
            Console.WriteLine(3);
            Console.WriteLine(4);
            Console.WriteLine(5);
            Console.WriteLine(6);
            Console.WriteLine(7);
            Console.WriteLine(8);
            Console.WriteLine(9);
            Console.WriteLine(10);

            //03. Rectangle Area
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int S = a * b;
            Console.WriteLine(S);

            //04. Inches to Centimeters
            double centimeteres = double.Parse(Console.ReadLine());
            double inches = centimeteres * 2.54;
            Console.WriteLine(inches);

            //05. Greeting by Name
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");

            //06. Concatenate Data
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            Console.WriteLine("You are " + firstName + " " + lastName + ", a " + age + "-years old person from " + town + ".");

            //07. Projects Creation
            string name = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());
            int hours = projects * 3;
            Console.WriteLine("The architect " + name + " will need " + hours + " hours to complete " + projects + " project/s.");

            //08. Pet Shop
            int foodDogs = int.Parse(Console.ReadLine());
            int foodCats = int.Parse(Console.ReadLine());
            double priceDogs = foodDogs * 2.50;
            double priceCats = foodCats * 4.0;
            double sum = priceCats + priceDogs;
            Console.WriteLine(sum + " lv.");

            //09. Yard Greening
            double space = double.Parse(Console.ReadLine());
            double price = space * 7.61;
            double discount = price * 0.18;
            double finalPrice = price - discount;
            Console.WriteLine("The final price is: " + finalPrice + " lv.");
            Console.WriteLine("The discount is: " + discount + " lv.");
        }
    }
}