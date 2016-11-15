using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.Employees.Repository;
using WTS.Employees.DataLayer;
using System.Collections.Generic;
using System.Linq;

namespace WTS.Employees.Test
{

    [TestClass]
    public class EmployeeRepositoryTest
    {
        IEmployeeRepository _repository;

        [TestInitialize]
        public void TestInit()
        {
            IEmployeeRepository repository = new EmployeeFakeRepository();
            _repository = repository;
          
        }


        [TestMethod]
        public void TestGetEmployees_EmpployeesReturned()
        {

            // arrange
            int month = 11;                 // arrange to get employees for november


            // act 
            IEnumerable<EmployeeViewModel> result = _repository.GetEmployees(month);
           

            // assert
            Assert.IsNotNull(result);                                                                                           // the result should not be null as there are employees for november
            Assert.IsTrue(result.Count() == 6);                                                                                 // there should be 6 employees for november
            Assert.IsTrue(result.Sum(t => t.TotalHours) == 124);                                                                // sum of all hours  worked by employees in november should be 124
            Assert.IsTrue(result.Count( s => s.Surname == "Brown" && s.FirstName == "John" && s.TotalHours == 28) == 1);        // John Brown has 28 hours
            Assert.IsTrue(result.Count(s => s.Surname == "Fearn" && s.FirstName == "Neil" && s.TotalHours == 8) == 1);          // Neil Fearn has eight hours
            Assert.IsFalse(result.Count(s => s.Surname == "White" && s.FirstName == "Alice" && s.TotalHours == 28) == 1);       // Alice White does not have a total of 28 hours (16 actually)

        }


        [TestMethod]
        public void TestGetEmployees_NoEmployeesReturned()
        {

            // arrange
            int month = 8;


            // act 
            IEnumerable<EmployeeViewModel> result = _repository.GetEmployees(month);


            // assert
            Assert.IsNotNull(result);                                                                                           // the result should not be null as there are employees for november
            Assert.IsTrue(result.Count() == 0);                                                                                 // there should be no employees listed for August
            
        }


        [TestCleanup]
        public void TestCleanup()
        {
            _repository = null;
        }


    }


}
