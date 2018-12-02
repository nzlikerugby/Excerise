using Model;
using MyDataIO;
using MyDataPreProcessor;
using MyServices;
using System;

namespace MyApp
{
    public class App : IApp
    {
        private static IDataIO dataIO = DataIO.GetDataIO();
        private static IDataPreProcessor dataPreProcessor = DataPreProcessor.GetProcessor();
        private static IServices service = Services.GetServices();

        public void GeneratePayslip(string fileName)
        {
            var stringLines = dataIO.ReadFile(fileName);
            var staffs = dataPreProcessor.GenerateStaffList(stringLines);
            var payslips = service.GeneratePayslips(staffs);
            dataIO.Output(payslips, OUTPUTTO.CONSOLE);
        }        
    }
}
