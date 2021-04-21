using QulixApp.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace QulixApp.DataAccessLayer.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        void AddCompany(string name, string organizationalName);
        void UpdateCompany(int id, string name, string organizationalName);
        void DeleteCompany(int id);
        Company ReadCompany(int id);
        List<Company> ReadAll();

    }
}
