using GreetingMessagingModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingMessagingRepositoryLayer
{
    public interface IUserEmployeeRepository
    {
        IEnumerable<GreetingEmployeeDetails> GetAllEmployees();
        GreetingEmployeeDetails AddEmployeeData(GreetingEmployeeDetails empoyeeDetails);
        object DeleteEmployeeData(int Id);
        GreetingEmployeeDetails UpdateEmployeeData(GreetingEmployeeDetails empoyeeDetails);
    }
}
