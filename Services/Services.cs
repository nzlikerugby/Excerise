using Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MyServices
{
    public class Services:IServices
    {
        private IStaff staff;
        private static Services service;
        // Not good solution
        Dictionary<string,string> payPeriods = new Dictionary<string, string>
        {
            { "01January-31January","01 January-31 January" },
            { "01February-28February","01 February-28 February" },
            { "01February-29February","01 February-29 February" },
            { "01March-31March", "01 March-31 March" },
            { "01April-30April", "01 April-30 April" },
            { "01May-31May", "01 May-31 May"},
            { "01June-30June",  "01 June-30 June"},
            { "01July-31July", "01 July-31 July" },
            { "01August-30August", "01 August-30 August" },
            { "01September-31September", "01 September-31 September"},
            { "01October-30October", "01 October-30 October"},
            { "01November-31November", "01November-31November" },
            { "01December-30December", "01 December-30 December" },

            { "1January-31January","01 January-31 January" },
            { "1February-28February","01 February-28 February" },
            { "1February-29February","01 February-29 February" },
            { "1March-31March", "01 March-31 March" },
            { "1April-30April", "01 April-30 April" },
            { "1May-31May", "01 May-31 May"},
            { "1June-30June",  "01 June-30 June"},
            { "1July-31July", "01 July-31 July" },
            { "1August-30August", "01 August-30 August" },
            { "1September-31September", "01 September-31 September"},
            { "1October-30October", "01 October-30 October"},
            { "1November-31November", "01November-31November" },
            { "1December-30December", "01 December-30 December" }
        };
        
        private Services()
        {            
        }
                
        public static Services GetServices()
        {
            if(service == null)
            {
                service = new Services();
            }
            return service;
        }

        public string OutputName(string firstName, string lastName)
        {
            // Assume firstname or lastname cannot be null or empty
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                throw new Exception("NAME CANNOT BE NULL OR EMPTY");
            }
            // Assume firstname or lastname length cannot exceed 20 characters
            if(firstName.Length > 20 || lastName.Length > 20)
            {
                throw new Exception("NAME CANNOT BE MORE THAN 20 CHARACTERS");
            }
            // Assume firstname or lastname only contains english character
            if(!Regex.IsMatch(firstName,@"^[a-zA-Z]*$") || !Regex.IsMatch(lastName, @"^[a-zA-Z]*$"))
            {
                throw new Exception("NAME CAN ONLY CONTAINS ENGLISH CHARACTER");
            }
            return firstName + " " + lastName;
        }

        public void Input(IStaff staff)
        {
            this.staff = staff;
        }

        public int OutputSuper(double? input_grossIncome, string input_superRate)
        {
            var grossIncome = ValidateInput(input_grossIncome);
            double superRate = 0;
            //if(!double.TryParse(input_superRate,out superRate))
            if (string.IsNullOrEmpty(input_superRate))
            {
                throw new Exception("SUPER RATE CANNOT BE NULL");
            }
            if(!double.TryParse(input_superRate.TrimEnd(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol.ToCharArray()),out superRate))
            {
                throw new Exception("WRONG INPUT FORMAT FOR SUPERRATE");
            }
            if (input_superRate.Contains('%'))
            {
                superRate = superRate / 100;
            }
            if(superRate < 0)
            {
                throw new Exception("SUPER RATE MUST BE GREATER THAN 0");
            }
            // (int) cast is faster than Math.Floor()
            return (int)(grossIncome * superRate);
        }

        public int OutputNetIncome(int? input_income, int? input_tax)
        {
            var input = ValidateInput(input_income);
            var tax = ValidateInput(input_tax);
            var netIncome = input - tax;
            if (netIncome <= 0)
            {
                throw new Exception("INCOME MUST BE GREATER THAN TAX");
            }
            return (int)netIncome;
        }

        public void ParseToDouble(string input, out double result)
        {
            if (!double.TryParse(input, out result))
            {
                throw new Exception("WRONG INPUT FORMAT");
            }
        }

        public int OutputIncomeTax(string input)
        {
            double salary = 0;
            ParseToDouble(input, out salary);
            if(salary < 0)
            {
                throw new Exception("SALARY MUST BE GREATER THAN 0");
            }
            if(salary>0 && salary <= 18200)
            {
                return 0;    
            }
            else if(salary > 18200 && salary <= 37000)
            {
                return (int)Math.Ceiling(((salary - 18200) * 0.19)/12);
            }
            else if (salary > 37001 && salary <= 87000)
            {
                return (int)((3572 + Math.Ceiling((salary - 37000) * 0.325))/12);
            }
            else if (salary > 87001 && salary <= 180000)
            {
                return (int)((19822 + Math.Ceiling((salary - 87000) * 0.37))/12);
            }
            else
            {
                return (int)((54232 + Math.Ceiling((salary - 180000) * 0.45))/12);
            }
        }

        public int OutputGrossIncome(string input)
        {
            CheckInputNullOrEmpty(input);
            double salary = 0;
            ParseToDouble(input, out salary);
            if (salary < 0)
            {
                throw new Exception("SALARY MUST BE GREATER THAN 0");
            }
            // (int) cast is faster than Math.Floor()
            return (int)(salary / 12);
        }

        public string OutputPayperiod(string inputPayperiod)
        {
            CheckInputNullOrEmpty(inputPayperiod);
            string payPeriod = inputPayperiod.Replace(" ", null);
            if (payPeriods.ContainsKey(payPeriod))
            {
                return payPeriods[payPeriod];
            }
            throw new Exception("INPUT DATE IN WRONG FORMAT");
        }

        //public void GetOutputConsole(string firstName, string lastName, string annualSalary, string superRate, string inputPayperiod)
        //{
        //    IStaff staff = ConvertInputToEmployee(firstName, lastName, annualSalary, superRate, inputPayperiod);
        //    CheckIfNullOrEmptyInputExist(staff);
        //    //ParseProcess(staff);
        //    GenerateFinalOutput(staff);
        //}

        public void GetOutputConsole(IStaff staff)
        {
            CheckIfNullOrEmptyInputExist(staff);
            //ParseProcess(staff);
            GeneratePayslip(staff);
        }

        public List<IPayslip> GeneratePayslips(List<IStaff> staffs)
        {
            if(staffs == null || staffs.Count == 0)
            {
                throw new ArgumentNullException("INPUT IS NULL OR EMPTY");
            }
            List<IPayslip> payslips = new List<IPayslip>();
            foreach(var staff in staffs)
            {
                payslips.Add(GeneratePayslip(staff));
            }
            return payslips;
        }

        public IPayslip GeneratePayslip(IStaff staff)
        {
            IPayslip payslip;
            try
            {
                var name = service.OutputName(staff.FirstName, staff.LastName);
                var payPeriod = service.OutputPayperiod(staff.PayPeriod);
                var grossIncome = service.OutputGrossIncome(staff.AnnualSalary);
                var incomeTax = service.OutputIncomeTax(staff.AnnualSalary);
                var netIncome = service.OutputNetIncome(grossIncome, incomeTax);
                var super = service.OutputSuper(grossIncome, staff.SuperRate);

                payslip = new Payslip
                {
                    Name = name,
                    PayPeriod = payPeriod,
                    GrossIncome = grossIncome,
                    IncomeTax = incomeTax,
                    NetIncome = netIncome,
                    Super = super
                };
                //Console.WriteLine($"{name}, {payPeriod}, {grossIncome}, {incomeTax}, {netIncome}, {super}");
                return payslip;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            return null;
        }

        public void CheckIfNullOrEmptyInputExist(IStaff staff)
        {
            var properties = staff.GetType().GetProperties();
            foreach(var p in properties)
            {
                var o = (string)(p.GetValue(staff));
                if (string.IsNullOrEmpty(o))
                {
                    throw new Exception("INPUT FIELD CANNOT BE NULL OR EMPTY");
                }
            }
        }

        //// Convert input to employee object
        //public IStaff ConvertInputToEmployee(string firstName, string lastName, string annualSalary, string superRate, string inputPayperiod)
        //{
        //    staff = new Employee
        //    {
        //        FirstName = firstName,
        //        LastName = lastName,
        //        AnnualSalary = annualSalary,
        //        SuperRate = superRate,
        //        PayPeriod = inputPayperiod
        //    };
        //    return staff;
        //}

        // Validate input
        public void CheckInputNullOrEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception("INPUT FIELD CANNOT BE NULL OR EMPTY");
            }

        }

        public double ValidateInput(double? input)
        {
            var amount = input ?? null;
            if (amount == null)
            {
                throw new Exception("AMOUNT CANNOT BE NULL");
            }
            if (amount < 0)
            {
                throw new Exception("AMOUNT MUST BE GREATER THAN 0");
            }
            return (double)amount;
        }

    }
}