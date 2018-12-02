using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IServices
    {
        List<IPayslip> GeneratePayslips(List<IStaff> staffs);
    }
}
