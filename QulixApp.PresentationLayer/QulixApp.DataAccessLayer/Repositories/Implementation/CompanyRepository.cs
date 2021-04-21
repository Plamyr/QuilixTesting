using QulixApp.DataAccessLayer.Domain;
using QulixApp.DataAccessLayer.Entities;
using QulixApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QulixApp.DataAccessLayer.Repositories.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDbCommand _dbCommand;
        public CompanyRepository(IDbConnection dbConnection, IDbCommand dbCommand)
        {
            _dbConnection = dbConnection;
            _dbCommand = dbCommand;
        }

        public void AddCompany(string name, string organizationalName)
        {
            _dbConnection.Open();
            string sql = $"Insert Into Company (Name,OrganizationalForm) Values(@Name, @organizationalForm)";
            _dbCommand.CommandText = sql;
            _dbCommand.Connection = _dbConnection;
            var nameparam = new SqlParameter("@Name", name);
            var organizationalparam = new SqlParameter("@organizationalForm", organizationalName);
            _dbCommand.Parameters.Add(nameparam);
            _dbCommand.Parameters.Add(organizationalparam);
            _dbCommand.ExecuteNonQuery();
            _dbConnection.Close();
        }
        public void UpdateCompany(int id, string name, string organizationalName)
        {
            _dbConnection.Open();
            string sql = string.Format("Update Company Set Name = '{0}', OrganizationalForm = '{1}' Where Id = '{2}'", name, organizationalName, id);
            _dbCommand.CommandText = sql;
            _dbCommand.Connection = _dbConnection;
            var reader = _dbCommand.ExecuteNonQuery();
            _dbConnection.Close();
        }
        public void DeleteCompany(int id)
        {
            _dbConnection.Open();
            string sql = string.Format("Delete from Company Where Id = '{0}'", id);
            _dbCommand.CommandText = sql;
            _dbCommand.Connection = _dbConnection;
            var reader = _dbCommand.ExecuteNonQuery();
            _dbConnection.Close();
        }
        public Company ReadCompany(int id)
        {
            _dbConnection.Open();
            string sql = string.Format("select Id, Name, OrganizationalForm from Company Where Id = '{0}'", id);
            _dbCommand.CommandText = sql;
            _dbCommand.Connection = _dbConnection;
            var reader = _dbCommand.ExecuteReader();
            reader.Read();
            var company = new Company()
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                OrganizationalForm = reader["OrganizationalForm"].ToString()
            };
            _dbConnection.Close();
            return company;
        }
        public List<Company> ReadAll()
        {
            List<Company> companies = new List<Company>();
            _dbConnection.Open();
            string sql = string.Format("select * from Company");
            _dbCommand.CommandText = sql;
            _dbCommand.Connection = _dbConnection;
            var reader = _dbCommand.ExecuteReader();
            while (reader.Read())
            {
                var company = new Company()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    OrganizationalForm = reader["OrganizationalForm"].ToString()
                };
                companies.Add(company);
            }
            _dbConnection.Close();
            return companies;
        }
    }
}
