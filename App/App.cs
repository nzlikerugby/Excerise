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
        /// <summary>
        /// DataIO instance
        /// </summary>
        private IDataIO dataIO;

        /// <summary>
        /// DatapreProcessor instance
        /// </summary>
        private IDataPreProcessor dataPreProcessor;

        /// <summary>
        /// Services instance
        /// </summary>
        private IServices service;
        
        public App(IDataIO dataIO,IDataPreProcessor dataPreProcessor,IServices service)
        {
            this.dataIO = dataIO;
            this.dataPreProcessor = dataPreProcessor;
            this.service = service;
        }

        /// <summary>
        /// Only API exposed for client to use
        /// </summary>
        /// <param name="fileName"></param>
        public void GeneratePayslip(string fileName)
        {
            var OutputOption = GenerateUI();
            var stringLines = dataIO.ReadFile(fileName);
            var staffs = dataPreProcessor.GenerateStaffList(stringLines);
            var payslips = service.GeneratePayslips(staffs);
            dataIO.Output(payslips, OutputOption);
        }   
        
        /// <summary>
        /// Provide a Console UI for client to choose output destination 
        /// </summary>
        /// <returns>option index</returns>
        private OUTPUTTO GenerateUI()
        {
            Console.WriteLine("                     WELCOME TO PAYSLIP                     ");
            Console.WriteLine("============================================================");
            Console.WriteLine(" Please choose one of following options for operation:");
            Console.WriteLine(" 1. Output to console only");
            Console.WriteLine(" 2. Output to file only");
            Console.WriteLine(" 3. Output to both console and file");
            Console.WriteLine(" 4. Quit");
            Console.WriteLine("============================================================");
            Console.WriteLine();
            return SelectOption();
        }

        /// <summary>
        /// Process keyboard input
        /// </summary>
        /// <returns></returns>
        private OUTPUTTO SelectOption()
        {
            var arr = new List<char> { '1', '2', '3', '4' };
            char c;
            do
            {
                Console.Write("Please choose 1,2,3,4 for payslip operation :");
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (!arr.Contains(c));
            return GetOutputOption(int.Parse(c.ToString()));
        }

        /// <summary>
        /// Return right corresponding Enum variable
        /// If '4' is selected then application will quit
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private OUTPUTTO GetOutputOption(int input)
        {
            switch (input)
            {
                case 1: return OUTPUTTO.CONSOLE;
                case 2: return OUTPUTTO.FILE;
                case 3: return OUTPUTTO.MANY;
                case 4: Environment.Exit(0);return OUTPUTTO.CONSOLE;
                default: return OUTPUTTO.CONSOLE;
            }
        }
    }
}
