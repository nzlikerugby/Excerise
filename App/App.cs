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
            Console.WriteLine(  "q. Quit");
            Console.WriteLine("============================================================");
            Console.Write("Please choose 1,2,3 or q for payslip operation :");
            return SelectOption();
        }

        private OUTPUTTO SelectOption()
        {
            var arr = new List<char> { '1', '2', '3', 'q' };
            char c;
            do
            {
                Console.Write("Please choose right option : ");
                c = Console.ReadKey().KeyChar;
                if (c == 'q')
                {
                    Environment.Exit(0);
                }
                Console.WriteLine();
            } while (!arr.Contains(c));
            return GetOutputOption(int.Parse(c.ToString()));
        }

        private OUTPUTTO GetOutputOption(int input)
        {
            if(input == 1)
            {
                return OUTPUTTO.CONSOLE;
            }
            else if(input == 2)
            {
                return OUTPUTTO.FILE;
            }
            else if(input == 3)
            {
                return OUTPUTTO.BOTH;
            }
            else
            {
                return OUTPUTTO.CONSOLE;
            }
        }
    }
}
