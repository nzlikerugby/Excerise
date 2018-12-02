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

                // use string input directly
                //service.GetOutputConsole("David", "Rudd", "60050", "11%", "01 March-31March");
                //Console.WriteLine("============================================================");



                // use IStaff object for input
                IDataIO dataIO = DataIO.GetDataIO();
                List<string> input = dataIO.ReadFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "payslip", "data", "input.csv"));
                IDataPreProcessor processor = DataPreProcessor.GetProcessor();
                List<IStaff> staff = processor.GenerateStaffList(input);
                Services service = Services.GetServices();
                List<IPayslip> payslips = service.GeneratePayslips(staff);
                dataIO.Output(payslips, OUTPUTTO.CONSOLE);

                Console.ReadKey();
                //service.GetOutputConsole("David", "Rudd", "60050", null, "01 March-31March");
                //Console.WriteLine("============================================================");
                //service.GetOutputConsole("David", "Rudd", "60050", "-0.01", "01 March-31March");
                //Console.WriteLine("============================================================");
                //service.GetOutputConsole("David", "Rudd", "-60050", null, "March-31March");
                //Console.WriteLine("============================================================");
                //service.GetOutputConsole("David", "Rudd", "60050", "0.12", "01 March-31");
                //Console.WriteLine("============================================================");
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
