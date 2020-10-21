using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SandBox
{
    public static class CoffeeMachine
    {
        //public static void Main(string[] args)
        //{
        //    var count = 0;
        //    while (true)
        //    {
        //        count++;

        //        var beverage = Console.ReadLine();
        //        var sugar = Console.ReadLine();
        //        var quantity = int.Parse(Console.ReadLine());

        //        var pricePerCup = 0.0;

        //        switch (beverage)
        //        {
        //            case "Espresso":
        //                switch (sugar)
        //                {
        //                    case "Without":
        //                        pricePerCup = 0.9;
        //                        break;

        //                    case "Normal":
        //                        pricePerCup = 1;
        //                        break;

        //                    case "Extra":
        //                        pricePerCup = 1.2;
        //                        break;
        //                }
        //                break;
        //            case "Cappuccino":
        //                switch (sugar)
        //                {
        //                    case "Without":
        //                        pricePerCup = 1;
        //                        break;

        //                    case "Normal":
        //                        pricePerCup = 1.2;
        //                        break;

        //                    case "Extra":
        //                        pricePerCup = 1.6;
        //                        break;
        //                }
        //                break;
        //            case "Tea":
        //                switch (sugar)
        //                {
        //                    case "Without":
        //                        pricePerCup = 0.5;
        //                        break;

        //                    case "Normal":
        //                        pricePerCup = 0.6;
        //                        break;

        //                    case "Extra":
        //                        pricePerCup = 0.7;
        //                        break;
        //                }
        //                break;
        //        }

        //        var totalPrice = pricePerCup * quantity;

        //        if (sugar == "Without")
        //        {
        //            totalPrice *= 0.65;
        //        }
        //        if (beverage == "Espresso" && quantity >= 5)
        //        {
        //            totalPrice *= 0.75;
        //        }
        //        if (pricePerCup * quantity > 15)
        //        {
        //            totalPrice *= 0.8;
        //        }
        //        Console.WriteLine($"You bought {quantity} cups of {beverage} for {totalPrice:f2} lv.");

        //        //File.WriteAllText($"../../../Test.00{count}.in.txt", $"{beverage}{Environment.NewLine}{sugar}{Environment.NewLine}{quantity}");
        //        //File.WriteAllText($"../../../Test.00{count}.out.txt", $"You bought {quantity} cups of {beverage} for {totalPrice:f2} lv.");
        //    }

        //}
    }
}
