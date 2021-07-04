﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWagesComputation
{
    class EmployeeWageBuilder
    {
        //adding constant global variable
        const int IS_FULL_TIME = 1;
        const int IS_PART_TIME = 2;

        LinkedList<EmployeeDetails> employeeDetailsList;
        public EmployeeWageBuilder()
        {
            this.employeeDetailsList = new LinkedList<EmployeeDetails>(); 
        }
        public void addDetail(string companyName, int employeeRatePerHr, int maxWorkingDays, int maxWorkingHrs)
        {
            EmployeeDetails employee= new EmployeeDetails( companyName, employeeRatePerHr, maxWorkingDays, maxWorkingHrs);
            this.employeeDetailsList.AddLast(employee);
        }

        public void ComputeWage()
        {
            foreach(EmployeeDetails employee in this.employeeDetailsList)
            {
                employee.SetEmployeeWage(this.ComputeEmployeeWage(employee));
                Console.WriteLine(employee.toString());
            }
        }

        private int ComputeEmployeeWage(EmployeeDetails details)
        {
            //initialize local variable 
            int empHrs = 0;
            int empWages = 0;
            int monthlyWages = 0;
            int workingHr = 0;
            int day = 0;
            //Creating object or instance of Random class
            Random random = new Random();


            //Calculatin monthly Wages for 20days or for 100Hrs of work
            while (day <= details.maxWorkingDays && workingHr < details.maxWorkingHrs)
            {


                //Generating Random value by calling Next Method
                int empInput = random.Next(0, 3);

                //Checking employee status using switch case statement
                switch (empInput)
                {
                    case IS_FULL_TIME:
                        empHrs = 8;
                        break;
                    case IS_PART_TIME:
                        empHrs = 4;
                        break;
                    default:
                        empHrs = 0;
                        break;
                }

                //calculating Daily wages of Employee by Working Hours
                empWages = empHrs * details.employeeRatePerHr;
                monthlyWages+= empWages;
                workingHr += empHrs;

                if (empInput != 0)
                {
                    day++;
                }

            }
           
            Console.WriteLine("Total working days :{0} \nTotal working hours:{1}", day, workingHr);
            return monthlyWages;
        }

      
    }
}
