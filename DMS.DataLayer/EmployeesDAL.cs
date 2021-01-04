using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DataLayer
{
    public class EmployeesDAL
    {

        /// <summary>
        /// March 18
        /// </summary>
        /// <param name="col"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Employee> GetEmployees(string col, string param)
        {
            SqlCommand cmd = new SqlCommand("sp_selectEmployeesFiltered", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@Column", col);
            cmd.Parameters.AddWithValue("@QueryString", param);
            return selectEmployees(cmd);
        }

        //Added - Dec 26th

        public List<Employee> GetEmployees()
        {
            SqlCommand cmd = new SqlCommand("sp_selectEmployeesAll", DALHelper.getConnection());
            return selectEmployees(cmd);
        }

        //Added - Dec 27th
        //To populate listbox for role

        public List<EmployeeRole> GetEmployeeRoles()
        {
            SqlCommand cmd = new SqlCommand("sp_selectEmployeeRolesAll", DALHelper.getConnection());
            return selectEmployeeRoles(cmd);
        }

        public List<Employee> GetEmployees_AttendanceToBeMarked()
        {
            SqlCommand cmd = new SqlCommand("sp_selectEmployees_AttendanceToBeMarked", DALHelper.getConnection());
            return selectEmployees(cmd);
        }


        //9 Jan
        public List<AttendanceStatus> GetEmployeeAttendanceStatuses()
        {
            SqlCommand cmd = new SqlCommand("sp_selectAttendanceStatusesAll", DALHelper.getConnection());
            return selectAttendanceStatuses(cmd);
        }

        /// <summary>
        /// Mar 18
        /// </summary>
        /// <param name="col"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<EmployeeAttendance> GetEmployeeAttendances(string col, string param)
        {
            SqlCommand cmd = new SqlCommand("sp_selectEmployeeAttendancesFiltered", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@Column", col);
            cmd.Parameters.AddWithValue("@QueryString", param);
            return selectEmployeeAttendances(cmd);
        }

        public List<EmployeeAttendance> GetEmployeeAttendances()
        {
            SqlCommand cmd = new SqlCommand("sp_selectEmployeeAttendancesAll", DALHelper.getConnection());
            return selectEmployeeAttendances(cmd);
        }

        public List<Employee> GetEmployees(int fromRank, int toRank)
        {
            SqlCommand cmd = new SqlCommand("categories_selectbypriorityrank", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@from", fromRank);
            cmd.Parameters.AddWithValue("@to", toRank);
            return selectEmployees(cmd);
        }

        public Employee GetEmployee(string id)
        {
            SqlCommand cmd = new SqlCommand("Employee_selectbyid", DALHelper.getConnection());
            cmd.Parameters.AddWithValue("@IdToSearch", id);
            //only one record will be found based on PK
            return selectEmployees(cmd)[0];
        }

        public int Insert(Employee emp)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertEmployee", con); 
            cmd.CommandType = CommandType.StoredProcedure;

            //Be EXTRA CAREFUL WHILE ENTERING PARAMETERS as Compiler doesn't pick it

            cmd.Parameters.AddWithValue("@Name", DALHelper.getNullORValue(emp.Name));
            cmd.Parameters.AddWithValue("@FatherName", DALHelper.getNullORValue(emp.FatherName));
            cmd.Parameters.AddWithValue("@DateofBirth", DALHelper.getNullORValue(emp.BirthDate.ToShortDateString()));
            cmd.Parameters.AddWithValue("@JoiningDate", DALHelper.getNullORValue(emp.JoiningDate.ToShortDateString()));
            cmd.Parameters.AddWithValue("@Salary", DALHelper.getNullORValue(emp.Salary));
            cmd.Parameters.AddWithValue("@Role", DALHelper.getNullORValue(emp.Role.ID));
            cmd.Parameters.AddWithValue("@Description", DALHelper.getNullORValue(emp.DutyDescription));
            cmd.Parameters.AddWithValue("@CurrentAddress", DALHelper.getNullORValue(emp.CurrentAddress));
            cmd.Parameters.AddWithValue("@PermanentAddress", DALHelper.getNullORValue(emp.PermanentAddress));
            cmd.Parameters.AddWithValue("@CNIC_No", DALHelper.getNullORValue(emp.CNIC_No));


            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }


        //09-Jan - For Attendance

        public int Insert(EmployeeAttendance attendance)
        {
            int cmd_success;
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("sp_insertEmployeeAttendance", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //Be EXTRA CAREFUL WHILE ENTERING PARAMETERS as Compiler doesn't pick it

   //         @EmployeeID int,
   //      @AttendanceDate datetime,
		 //@StatusID int

            cmd.Parameters.AddWithValue("@EmployeeID", DALHelper.getNullORValue(attendance.Emp.ID));
            cmd.Parameters.AddWithValue("@StatusID", DALHelper.getNullORValue(attendance.Status.ID));
            cmd.Parameters.AddWithValue("@AttendanceDate", DALHelper.getNullORValue(attendance.AttendanceDateTime));

            con.Open();
            using (con)
            {
                //Modified by Talha: Jan 26th, 2012 - Added Return variable to ensure data inserted successfully
                cmd_success = cmd.ExecuteNonQuery();
            }

            return cmd_success;
        }

        public void Update(Employee Employee)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("categories_update", con);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@IdToSearch", Employee.ID);
            //cmd.Parameters.AddWithValue("@name", Employee.Name);
            //cmd.Parameters.AddWithValue("@priorityrank", Employee.Father_Name);
            //cmd.Parameters.AddWithValue("@description", DALHelper.getNullORValue(Employee.Description));
            //cmd.Parameters.AddWithValue("@ImageUrl", DALHelper.getNullORValue(Employee.Class_Name));
            //cmd.Parameters.AddWithValue("@thumbnailUrl", DALHelper.getNullORValue(Employee.Section));

            con.Open();

            using (con)
            {
                int temp = cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Employee Employee)
        {
            SqlConnection con = DALHelper.getConnection();
            SqlCommand cmd = new SqlCommand("categories_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdToSearch", Employee.ID);
            con.Open();
            using (con)
            {
                int temp = cmd.ExecuteNonQuery();
            }
        }

        private List<Employee> selectEmployees(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<Employee> Employees = new List<Employee>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Employees = new List<Employee>();
                    while (dr.Read())
                    {
                        Employee emp = new Employee
                        {
                            ID = Convert.ToString(dr["ID"]),
                            Name = Convert.ToString(dr[1]),
                            FatherName = Convert.ToString(dr[2]),
                            BirthDate = Convert.ToDateTime(dr[3]),
                            JoiningDate = Convert.ToDateTime(dr[4]),
                            Salary = Convert.ToInt32(dr[5]),
                            Role = new EmployeeRole(0, Convert.ToString(dr[6])),            // 0 as we don't need Employee Role's ID when showing employees
                            DutyDescription = Convert.ToString(dr[7]),
                            CurrentAddress = Convert.ToString(dr[8]),
                            PermanentAddress = Convert.ToString(dr[9]),
                            CNIC_No = Convert.ToString(dr[10]),
                        };

                        Employees.Add(emp);
                    }
                }
            }
            return Employees;
        }

        private List<EmployeeAttendance> selectEmployeeAttendances(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<EmployeeAttendance> listAttendance = new List<EmployeeAttendance>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    listAttendance = new List<EmployeeAttendance>();
                    while (dr.Read())
                    {

                        EmployeeRole role = new EmployeeRole();

                        role.ID = Convert.ToInt32(dr[3]);
                        role.Description = Convert.ToString(dr[4]);

                        Employee currEmployee = new Employee();
                        currEmployee.ID = Convert.ToString(dr[1]);
                        currEmployee.Name = Convert.ToString(dr[2]);

                        AttendanceStatus currAttendanceStatus = new AttendanceStatus()
                        {
                            ID = Convert.ToInt32(dr[5]),
                            Description = Convert.ToString(dr[6])
                        };

                        EmployeeAttendance attendance = new EmployeeAttendance
                        {
                            AttendanceDateTime = Convert.ToDateTime(dr[0]),
                            Emp = currEmployee,
                            Status = currAttendanceStatus
                        };

                        listAttendance.Add(attendance);
                    }
                }
            }
            return listAttendance;
        }

        private List<EmployeeRole> selectEmployeeRoles(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<EmployeeRole> EmployeeRoles = new List<EmployeeRole>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    EmployeeRoles = new List<EmployeeRole>();
                    while (dr.Read())
                    {
                        EmployeeRole role = new EmployeeRole(Convert.ToInt32(dr[0]), Convert.ToString(dr[1]));

                        EmployeeRoles.Add(role);
                    }
                }
            }
            return EmployeeRoles;
        }

        private List<AttendanceStatus> selectAttendanceStatuses(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = cmd.Connection;
            List<AttendanceStatus> listStatuses = new List<AttendanceStatus>();
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    listStatuses = new List<AttendanceStatus>();
                    while (dr.Read())
                    {
                        AttendanceStatus st = new AttendanceStatus
                        {
                            ID = Convert.ToInt32(dr[0]),
                            Description = Convert.ToString(dr[1])
                        };

                        listStatuses.Add(st);
                    }
                }
            }
            return listStatuses;
        }

    }
}
