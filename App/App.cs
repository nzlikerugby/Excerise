using Model;
using MyDataIO;
using MyDataPreProcessor;
using MyServices;
using System;
using System.Collections.Generic;

namespace MyApp
{
    public class App : IApp
    {
        private static IDataIO dataIO = DataIO.GetDataIO();
        private static IDataPreProcessor dataPreProcessor = DataPreProcessor.GetProcessor();
        private static IServices service = Services.GetServices();
                
        public void GeneratePayslip(string fileName)
        {
            var OutputOption = GenerateUI();
            var stringLines = dataIO.ReadFile(fileName);
            var staffs = dataPreProcessor.GenerateStaffList(stringLines);
            var payslips = service.GeneratePayslips(staffs);
            dataIO.Output(payslips, OutputOption);
        }   
        
        private OUTPUTTO GenerateUI()
        {
            Console.WriteLine("                     WELCOME TO PAYSLIP                     ");
            Console.WriteLine("============================================================");
            Console.WriteLine(  "Please choose one of following options for operation:");
            Console.WriteLine(  "1. Console output only");
            Console.WriteLine(  "2. File output only");
            Console.WriteLine(  "3. Both above");
            Console.WriteLine(  "4. Quit");
            Console.WriteLine("============================================================");
            Console.Write("Please choose 1,2,3,4 for payslip operation :");
            return SelectOption();
        }

        private OUTPUTTO SelectOption()
        {
            var arr = new List<char> { '1', '2', '3', '4' };
            char c;
            do
            {
                Console.Write("Please choose right option : ");
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (!arr.Contains(c));
            return GetOutputOption(int.Parse(c.ToString()));
        }

        private OUTPUTTO GetOutputOption(int input)
        {
            switch (input)
            {
                case 1: return OUTPUTTO.CONSOLE;
                case 2: return OUTPUTTO.FILE;
                case 3: return OUTPUTTO.BOTH;
                case 4: Environment.Exit(0);return OUTPUTTO.CONSOLE;
                default: return OUTPUTTO.CONSOLE;
            }
        }
    }
}
