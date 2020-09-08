using GreetingMessagingModelLayer;
using GreetingMessagingRepositoryLayer;
using System;
using System.Collections.Generic;

namespace GreetingMessagingBussinessLayer
{
    public class GreetingMessagingBussiness:IGreetingMessagingBussiness
    {
        public readonly IUserEmployeeRepository employeeRepository;
        public GreetingMessagingBussiness(IUserEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<GreetingEmployeeDetails> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        public GreetingEmployeeDetails AddEmployeeData(GreetingEmployeeDetails empoyeeDetails)
        {
            return employeeRepository.AddEmployeeData(empoyeeDetails);
        }
       
        public object DeleteEmployeeData(int Id)
        {
            return employeeRepository.DeleteEmployeeData(Id);
        }

        public GreetingEmployeeDetails UpdateEmployeeData(GreetingEmployeeDetails empoyeeDetails)
        {
            return employeeRepository.UpdateEmployeeData(empoyeeDetails);
        }
    }
}
