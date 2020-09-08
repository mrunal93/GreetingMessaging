using GreetingMessagingModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingMessagingBussinessLayer
{
    public interface IGreetingMessagingBussiness
    {
        IEnumerable<GreetingEmployeeDetails> GetAllEmployees();
        GreetingEmployeeDetails AddEmployeeData(GreetingEmployeeDetails empoyeeDetails);
        object DeleteEmployeeData(int Id);
        GreetingEmployeeDetails UpdateEmployeeData(GreetingEmployeeDetails empoyeeDetails);
    }
}
