using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SandBox
{
    public class Functional_Programming_Exercise
    {
        public static void Main(string[] args)
        {

            Func<int, string> func = TestMethod; // a=>a.ToString()
            Action<int> action = TestAction;// a=>Console.WriteLine(a);

            Func<Func<int, string>, string> foo = TestMethod => TestMethod(3).ToString();
            Console.WriteLine(func(4));
            action(3);

            string a = "This is a test => sentance";

            var result = a.Split(new string[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(result);
            ;
        }

        public static string TestMethod(int a)
        {
            return a.ToString();
        }

        public static void TestAction(int a)
        {
            Console.WriteLine(a);
        }

    }
}
