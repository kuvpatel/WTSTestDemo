using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTS.Employees.DataLayer;

namespace WTS.Employees.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private EmployeeData _dbContext = null;

        public EmployeeRepository()
        {
            _dbContext = new EmployeeData();
        }


        #region sp_GetEmployeeHours details

        /*
             create proc sp_GetEmployeeHours
              (
                  @Month int
              )
              as
              begin
              set nocount on;
              select 
                  e.Employee_ID, 
                  e.FirstName, 
                  e.Surname,  
                  sum(DATEDIFF(hour, s.shift_start, s.shift_end)) as TotalHours
              from employee e
                  inner join [dbo].[Employee_Works_Shift] ws on e.employee_ID = ws.employee_id
                  inner join [dbo].[Shifts] s on s.shift_id = ws.shift_id
              where 
                  datepart(mm,s.Shift_Start) = @Month and datepart(mm, s.shift_end) = @Month
              group by 
                  e.Employee_ID, e.FirstName, e.Surname
              end
      */

        #endregion

        public IEnumerable<EmployeeViewModel> GetEmployees(int MonthFilter)
        {
            var MonthParameter = new SqlParameter("@Month", MonthFilter);

            var result = _dbContext.Database
                .SqlQuery<EmployeeViewModel>("sp_GetEmployeeHours @Month", MonthParameter)
                .ToList();

            return result;
        }

    }

}
