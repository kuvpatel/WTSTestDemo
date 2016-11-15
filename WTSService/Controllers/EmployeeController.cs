using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WTS.Employees.Repository;
using WTS.Employees.DataLayer;

namespace WTSService.Controllers
{
    public class EmployeeController : ApiController
    {

        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }


        //// GET api/<controller>/5
        [AllowAnonymous]
        public IEnumerable<EmployeeViewModel> Get(int id)
        {

            return _repository.GetEmployees(id);
        }

       
    }
}