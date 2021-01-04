using System;

namespace DMS.Entities
{
    public class EmployeeAttendance
    {
        Employee emp;
        DateTime attendanceDateTime;
        AttendanceStatus status;

        public Employee Emp
        {
            get
            {
                return emp;
            }

            set
            {
                emp = value;
            }
        }

        public DateTime AttendanceDateTime
        {
            get
            {
                return attendanceDateTime;
            }

            set
            {
                attendanceDateTime = value;
            }
        }

        public AttendanceStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
    }
}
