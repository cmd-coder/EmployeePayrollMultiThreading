using EmployeePayrollMultiThreading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EmployeePayrollUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();

        [TestInitialize]
        public void InitializeTests()
        {
            employeeDetails.Add(new EmployeeDetails() { Name = "DBName", StartDate = Convert.ToDateTime("01/01/2020"), Gender = "M", Phone = "9090909090", Basic = 456456, Address = "DBAddress", Deduction = 78894556, Department = "DBDepartment", TaxablePay = 12231223, NetPay = 124556, Tax = 455623 });
            employeeDetails.Add(new EmployeeDetails() { Name = "DBName2", StartDate = Convert.ToDateTime("02/02/2020"), Gender = "F", Phone = "9094509090", Basic = 456456, Address = "DBAddress2", Deduction = 78894556, Department = "DBDepartment2", TaxablePay = 12231223, NetPay = 124556, Tax = 455623 });
            employeeDetails.Add(new EmployeeDetails() { Name = "DBName3", StartDate = Convert.ToDateTime("03/03/2020"), Gender = "T", Phone = "9090989090", Basic = 456456, Address = "DBAddress3", Deduction = 78894556, Department = "DBDepartment3", TaxablePay = 12231223, NetPay = 124556, Tax = 455623 });

        }


        [TestMethod]
        public void TestAddEmployeeToPayrollofDataBaseHandlerClassPassListOfEmployeesAndReceiveTheNumberOfRowsAffected()
        {
            DateTime startDateTime = DateTime.Now;
            int rows=DataBaseHandler.AddEmployeeToPayroll(employeeDetails);
            DateTime endDateTime = DateTime.Now;
            Console.WriteLine("The time taken for execution is: " + (endDateTime - startDateTime));
            Assert.AreEqual(3, rows);
        }

        [TestMethod]
        public void TestAddEmployeeToPayrollUsingThreadsofDataBaseHandlerClassPassListOfEmployeesAndReceiveTheNumberOfRowsAffected()
        {
            DateTime startDateTimeThread = DateTime.Now;
            int rowsThread = DataBaseHandler.AddEmployeeToPayrollUsingThreads(employeeDetails);
            DateTime endDateTimeThread = DateTime.Now;
            Console.WriteLine("The time taken for execution is: " + (endDateTimeThread - startDateTimeThread));
            //Assert.AreEqual(3, rowsThread);
        }
    }
}
