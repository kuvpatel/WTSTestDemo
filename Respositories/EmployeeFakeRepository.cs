using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTS.Employees.DataLayer;
using WTS.Employees.Repository;

namespace WTS.Employees.Repository
{
    public class EmployeeFakeRepository : IEmployeeRepository
    {

        private EmployeeData _dbContext = null;


        public EmployeeFakeRepository()
        {
            _dbContext = new EmployeeData("EmployeeDataTest");
        }


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
