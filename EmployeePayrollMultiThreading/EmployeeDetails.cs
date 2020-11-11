using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollMultiThreading
{
    public class EmployeeDetails
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public double Basic { get; set; }
        public string Address { get; set; }
        public double Deduction { get; set; }
        public string Department { get; set; }
        public double TaxablePay { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }

    }
}