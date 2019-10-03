using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace _22_WCF_Assignment_02
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool AddEmployee(Employee employee);
        [OperationContract]
        List<Employee> RetreiveEmployees();
        [OperationContract]
        Employee RetreiveEmployeeByID(int employeeId);
        [OperationContract]
        bool UpdateEmployee(Employee employee);
        [OperationContract]
        bool DeleteEmployee(int employeeId);
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmpId { get; set; }
        [DataMember]
        public string EmpFna { get; set; }
        [DataMember]
        public string EmpLna { get; set; }
        [DataMember]
        public string Dept { get; set; }
    }
}
