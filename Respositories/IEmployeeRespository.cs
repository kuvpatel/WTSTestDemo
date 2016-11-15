using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTS.Employees.DataLayer;

namespace WTS.Employees.Repository
{
    public interface IEmployeeRepository
    {

        IEnumerable<EmployeeViewModel> GetEmployees(int MonthFilter);

    }
}
