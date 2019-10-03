using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _22_WCF_Assignment_02
{
    public class EmployeeRepository
    {
        private SqlConnection sqlCon;

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>();
            try
            {
                using (sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["PROD"].ConnectionString))
                {
                    SqlCommand sqlComm = new SqlCommand("usp_GetAllEmployees", sqlCon);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                    DataTable dt = new DataTable();
                    sqlCon.Open();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            employeeList.Add(new Employee
                            {
                                EmpId = Convert.ToInt32(dr["EmpId"]),
                                EmpFna = dr["EmpFna"].ToString(),
                                EmpLna = dr["EmpLna"].ToString(),
                                Dept = dr["Dept"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return employeeList;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = new Employee();
            try
            {
                using (sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["PROD"].ConnectionString))
                {
                    SqlCommand sqlComm = new SqlCommand("usp_GetEmployeeById", sqlCon);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@employeeId", employeeId);
                    SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                    DataTable dt = new DataTable();
                    sqlCon.Open();
                    da.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        employee.EmpId = Convert.ToInt32(dt.Rows[0]["EmpId"]);
                        employee.EmpFna = dt.Rows[0]["EmpFna"].ToString();
                        employee.EmpLna = dt.Rows[0]["EmpLna"].ToString();
                        employee.Dept = dt.Rows[0]["Dept"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return employee;
        }

        public bool InsertEmployee(Employee employee)
        {
            bool returnVal = false;
            try
            {
                using (sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["PROD"].ConnectionString))
                {
                    SqlCommand sqlComm = new SqlCommand("usp_InsertEmployee", sqlCon);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@empFna", employee.EmpLna);
                    sqlComm.Parameters.AddWithValue("@empLna", employee.EmpLna);
                    sqlComm.Parameters.AddWithValue("@dept",employee.Dept);
                    sqlCon.Open();
                    var result = sqlComm.ExecuteNonQuery();
                    if (result > 0)
                        returnVal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return returnVal;
        }

        public bool UpdateEmployee(Employee employee)
        {
            bool returnVal = false;
            try
            {
                using (sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["PROD"].ConnectionString))
                {
                    SqlCommand sqlComm = new SqlCommand("usp_UpdateEmployee", sqlCon);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@empId", employee.EmpId);
                    sqlComm.Parameters.AddWithValue("@empFna", employee.EmpFna);
                    sqlComm.Parameters.AddWithValue("@empLna", employee.EmpLna);
                    sqlComm.Parameters.AddWithValue("@dept", employee.Dept);
                    sqlCon.Open();
                    var result = sqlComm.ExecuteNonQuery();
                    if (result > 0)
                        returnVal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return returnVal;
        }

        public bool DeleteEmployee(int employeeId)
        {
            bool returnVal = false;
            try
            {
                using (sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["PROD"].ConnectionString))
                {
                    SqlCommand sqlComm = new SqlCommand("usp_DeleteEmployee", sqlCon);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@empId", employeeId);
                    sqlCon.Open();
                    var result = sqlComm.ExecuteNonQuery();
                    if (result > 0)
                        returnVal = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return returnVal;
        }
    }
}