using DMS.DataLayer;
using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DMS.BusinessLayer
{
    public class EmployeesHandler
    {


        public List<Employee> GetEmployees(string col, string param)
        {
            return new EmployeesDAL().GetEmployees(col,param);
        }

        public List<EmployeeAttendance> GetEmployeeAttendances(string col, string param)
        {
            return new EmployeesDAL().GetEmployeeAttendances(col, param);
        }

        public List<Employee> GetEmployees()
        {
            return new EmployeesDAL().GetEmployees();
        }

        public List<EmployeeRole> GetEmployeeRoles()
        {
            return new EmployeesDAL().GetEmployeeRoles();
        }

        public List<EmployeeAttendance> GetEmployeeAttendances()
        {
            return new EmployeesDAL().GetEmployeeAttendances();
        }

        public List<AttendanceStatus> GetEmployeeAttendanceStatuses()
        {
            return new EmployeesDAL().GetEmployeeAttendanceStatuses();
        }


        public List<Employee> GetEmployees(int fromRank, int toRank)
        {
            return new EmployeesDAL().GetEmployees(fromRank, toRank);
        }

        //For Attendance as only once an employee is marked, should not be marked again. 9 Jan
        public List<Employee> GetEmployees_AttendanceToBeMarked()
        {
            return new EmployeesDAL().GetEmployees_AttendanceToBeMarked();
        }

        public Employee GetEmployee(string id)
        {
            return new EmployeesDAL().GetEmployee(id);
        }

        public int AddEmployee(Employee Employee)
        {
            //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
            int cmd_success;
            cmd_success = new EmployeesDAL().Insert(Employee);
            return cmd_success;
        }

        public int AddEmployeeAttendance(EmployeeAttendance attendance)
        {
            //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
            int cmd_success;
            cmd_success = new EmployeesDAL().Insert(attendance);
            return cmd_success;
        }


        public void UpdateEmployee(Employee Employee)
        {
            new EmployeesDAL().Update(Employee);
        }

        public void DeleteEmployee(Employee Employee)
        {
            new EmployeesDAL().Delete(Employee);
        }

    }
}
