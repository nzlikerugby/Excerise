using Model;
using MyServices;
using System;

namespace Payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            Services service = Services.GetServices();
            //IStaff staff = service.ConvertInputToEmployee("David", "Rudd", "60050", "0.09", "01 March-31March");
            try
            {
                // use string input directly
                //service.GetOutputConsole("David", "Rudd", "60050", "11%", "01 March-31March");
                //Console.WriteLine("============================================================");

                // use IStaff object for input
                IStaff staff = new Employee { FirstName = "David", LastName = "Zhao", AnnualSalary = "60050", SuperRate = "10%", PayPeriod = "01 March-31March" };
                service.GetOutputConsole(staff);

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
                
            Console.ReadKey();
                        
            Console.WriteLine("Test finished");



        }
    }
}
