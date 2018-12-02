using Model;
using MyApp;
using MyDataIO;
using MyDataPreProcessor;
using MyServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace Payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var app = new App();
                var file = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "payslip", "data", "input.csv");
                app.GeneratePayslip(file);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            Console.WriteLine("Test finished. Press any key to quit");
            Console.ReadKey();
        }
    }
}
