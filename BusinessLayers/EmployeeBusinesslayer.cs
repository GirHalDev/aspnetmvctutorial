﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLayers
{
    public class EmployeeBusinesslayer
    {
        public IEnumerable<Employee> Employees
        {
            //ADO.Net only to read the data, not to change or add data
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                List<Employee> employees = new List<Employee>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.ID = Convert.ToInt32(rdr["Id"]);
                        employee.FirstName = rdr["FirstName"].ToString();
                        employee.LastName = rdr["LastName"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Salary = rdr["Salary"].ToString();
                        employee.DepartmentId = rdr["DepartmentId"].ToString();
                        if(!(rdr["DateOfBirth"] is DBNull))
                        {
                            employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                        }
                       

                        employees.Add(employee);

                    }
                }

                return employees;
            }

        }

        //Should insert the given data to the database Employee
        public void AddEmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramFirstName = new SqlParameter();
                paramFirstName.ParameterName = "@FirstName";
                paramFirstName.Value = employee.FirstName;
                cmd.Parameters.Add(paramFirstName);

                SqlParameter paramLastName = new SqlParameter();
                paramLastName.ParameterName = "@LastName";
                paramLastName.Value = employee.LastName;
                cmd.Parameters.Add(paramLastName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramSalary = new SqlParameter();
                paramSalary.ParameterName = "@Salary";
                paramSalary.Value = employee.Salary;
                cmd.Parameters.Add(paramSalary);

                SqlParameter paramDepartmentId = new SqlParameter();
                paramDepartmentId.ParameterName = "@DepartmentId";
                paramDepartmentId.Value = employee.DepartmentId;
                cmd.Parameters.Add(paramDepartmentId);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveEmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@ID";
                paramID.Value = employee.ID;
                cmd.Parameters.Add(paramID);

                SqlParameter paramFirstName = new SqlParameter();
                paramFirstName.ParameterName = "@FirstName";
                paramFirstName.Value = employee.FirstName;
                cmd.Parameters.Add(paramFirstName);

                SqlParameter paramLastName = new SqlParameter();
                paramLastName.ParameterName = "@LastName";
                paramLastName.Value = employee.LastName;
                cmd.Parameters.Add(paramLastName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramSalary = new SqlParameter();
                paramSalary.ParameterName = "@Salary";
                paramSalary.Value = employee.Salary;
                cmd.Parameters.Add(paramSalary);

                SqlParameter paramDepartmentId = new SqlParameter();
                paramDepartmentId.ParameterName = "@DepartmentId";
                paramDepartmentId.Value = employee.DepartmentId;
                cmd.Parameters.Add(paramDepartmentId);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteEmployee(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@id";
                paramID.Value = id;
                cmd.Parameters.Add(paramID);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
