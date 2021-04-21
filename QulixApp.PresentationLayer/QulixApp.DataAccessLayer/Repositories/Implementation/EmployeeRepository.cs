using QulixApp.DataAccessLayer.Domain;
using QulixApp.DataAccessLayer.Entities;
using QulixApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QulixApp.DataAccessLayer.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDbCommand _dbCommand;

        public EmployeeRepository(IDbConnection dbConnection, IDbCommand dbCommand)
        {
            _dbConnection = dbConnection;
            _dbCommand = dbCommand;
        }

        public void AddEmployee(string lastNane, string firstName, DateTime date, string patronym, string pos, int companyId)
        {
            _dbConnection.Open();
                string sql = string.Format("Insert Into Employee" +
                   "(LastName,FirstName,Patronymic, Position, EmploymentDate,CompanyId) Values(@LastName,@FirstName,@Patronymic,@Position,@EmploymentDate,@CompanyId)");
            _dbCommand.CommandText = sql;
            _dbCommand.Connection = _dbConnection;
            var lastname = new SqlParameter("@LastName",lastNane);
            var firstnamme = new SqlParameter("@FirstName",firstName);
            var datee = new SqlParameter("@EmploymentDate",date);
            var patronymic = new SqlParameter("@Patronymic",patronym);
            var position = new SqlParameter("@Position",pos);
            var company = new SqlParameter("@CompanyId",companyId);
            _dbCommand.Parameters.Add(lastname);
            _dbCommand.Parameters.Add(firstnamme);
            _dbCommand.Parameters.Add(datee);
            _dbCommand.Parameters.Add(company);
            _dbCommand.Parameters.Add(patronymic);
            _dbCommand.Parameters.Add(position);
            _dbCommand.ExecuteNonQuery();
            _dbConnection.Close();
        }
        public void UpdateEmployee(int id, string lastName, string firstName, string Patronymic, string Position, DateTime date, int companyId)
        {
            _dbConnection.Open();
                string sql = string.Format("Update Employee Set LastName = '{0}', FirstName = '{1}', EmploymentDate = '{2}', Patronymic = '{3}', Position = '{4}',CompanyId = '{5}' Where Id = '{6}'", lastName, firstName ,date,Patronymic,Position, companyId, id);
            _dbCommand.CommandText = sql;
            _dbCommand.Connection = _dbConnection;
            _dbCommand.ExecuteNonQuery();
            _dbConnection.Close();
        }
        public void DeleteEmployee(int id)
        {
            _dbConnection.Open();
                string sql = string.Format("Delete from Employee Where Id = '{0}'", id);
            _dbCommand.CommandText = sql;
            _dbCommand.Connection = _dbConnection;
            _dbCommand.ExecuteNonQuery();
            _dbConnection.Close();
        }
        public Employee ReadEmployee(int id)
        {
            _dbConnection.Open();
                string sql = string.Format("select * from Company Where Id = '{0}'", id);
            _dbCommand.CommandText = sql;
            _dbCommand.Connection = _dbConnection;
            var reader = _dbCommand.ExecuteReader();
            reader.Read();
            var employee = new Employee()
            {
                Id = (int)reader["Id"],
                LastName = reader["LastName"].ToString(),
                FirstName = reader["LastName"].ToString(),
                Patronymic = reader["Patronymic"].ToString(),
                Position = reader["Position"].ToString(),
                EmploymentDate = (DateTime)reader["EmploymentDate"],
                CompanyId = (int)reader["CompanyId"]
            };
            _dbConnection.Close();
            return employee;
        }
        public List<Employee> ReadAll()
        {
            List<Employee> employees = new List<Employee>();
            _dbConnection.Open();
                string sql = string.Format("select * from Employee");
            _dbCommand.CommandText = sql;
            _dbCommand.Connection = _dbConnection;
            var reader = _dbCommand.ExecuteReader();
            while (reader.Read())
            {
                var employee = new Employee()
                {
                    Id = (int)reader["Id"],
                    LastName = reader["LastName"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    Patronymic = reader["Patronymic"].ToString(),
                    Position = reader["Position"].ToString(),
                    EmploymentDate = (DateTime)reader["EmploymentDate"],
                    CompanyId = (int)reader["CompanyId"]
                };
                employees.Add(employee);
            }
            _dbConnection.Close();
            return employees;
        }
    }
}
