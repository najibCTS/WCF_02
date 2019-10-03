using System.Collections.Generic;

namespace _22_WCF_Assignment_02
{
    public class Service1 : IService1
    {
        EmployeeRepository empRepo = new EmployeeRepository();
        public bool AddEmployee(Employee employee)
        {
            return empRepo.InsertEmployee(employee);
        }

        public List<Employee> RetreiveEmployees()
        {
            return empRepo.GetAllEmployees();
        }

        public Employee RetreiveEmployeeByID(int employeeId)
        {
            return empRepo.GetEmployeeById(employeeId);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return empRepo.UpdateEmployee(employee);
        }

        public bool DeleteEmployee(int employeeId)
        {
            return empRepo.DeleteEmployee(employeeId);
        }
    }
}
