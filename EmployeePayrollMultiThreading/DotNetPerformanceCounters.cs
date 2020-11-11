using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EmployeePayrollMultiThreading
{
    class DotNetPerformanceCounters
    {
        List<PerformanceCounter> lstPerfCounters = new List<PerformanceCounter>();
        public virtual void InitializeCounters(string AppInstanceName, Type PerfCountersList)
        {
            foreach (string counterName in Enum.GetNames(PerfCountersList))
            {
                PerformanceCounter PerfCounter = new PerformanceCounter();
                PerfCounter.CategoryName = ".NET Data Provider for SqlServer";
                PerfCounter.CounterName = counterName;
                PerfCounter.InstanceName = AppInstanceName;
                lstPerfCounters.Add(PerfCounter);
            }
        }
        public virtual void PrintCounters()
        {
            foreach (PerformanceCounter p in lstPerfCounters)
            {
                Console.WriteLine("{0} = {1}", p.CounterName, p.NextValue());
            }
            Console.WriteLine("****************************************************************");
        }
    }
}
