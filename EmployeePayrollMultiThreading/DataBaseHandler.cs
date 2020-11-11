using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollMultiThreading
{
    public class DataBaseHandler
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=DESKTOP-DKOUJ1R\SQLEXPRESS;Initial Catalog=payroll_service;Integrated Security=True");
        }

        public static int AddEmployeeToPayroll(List<EmployeeDetails> list)
        {
            int rows = 0;

            list.ForEach(item =>
            {
                string query = "INSERT INTO employee_payroll VALUES('" + item.Name +
                  "','" + item.StartDate + "','" + item.Gender + "','" + item.Address + "','" + item.Phone + "','" + item.Department
                  + "','" + item.Basic + "','" + item.Deduction + "','"+item.TaxablePay+"','"+item.Tax+"','"+item.NetPay+"');";

                SqlConnection sqlConnection = ConnectionSetup();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    rows+=sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Records Inserted Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated In InsertIntoDataBase. Details: " + e.ToString());
                }
                finally
                {
                    sqlConnection.Close();
                }

            });
            return rows;
        }


        public static int AddEmployeeToPayrollUsingThreads(List<EmployeeDetails> list)
        {
            int rows = 0;

            list.ForEach(item =>
            {
                Task thread = new Task(() =>
                  {
                      string query = "INSERT INTO employee_payroll VALUES('" + item.Name +
                        "','" + item.StartDate + "','" + item.Gender + "','" + item.Address + "','" + item.Phone + "','" + item.Department
                        + "','" + item.Basic + "','" + item.Deduction + "','" + item.TaxablePay + "','" + item.Tax + "','" + item.NetPay + "');";

                      SqlConnection sqlConnection = ConnectionSetup();
                      SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                      try
                      {
                          sqlConnection.Open();
                          rows += sqlCommand.ExecuteNonQuery();
                          Console.WriteLine("Records Inserted Successfully");
                      }
                      catch (SqlException e)
                      {
                          Console.WriteLine("Error Generated In InsertIntoDataBase. Details: " + e.ToString());
                      }
                      finally
                      {
                          sqlConnection.Close();
                      }
                  });
                thread.Start();

            });
            return rows;
        }
    }
}
