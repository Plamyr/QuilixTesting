using QulixApp.BusinessLogicLayer.DtoModels;
using System.Collections.Generic;

namespace QulixApp.BusinessLogicLayer.Services.Interfaces
{
    public interface ICompanyService
    {
        CompanyDto GetCompany(int id);
        List<CompanyDto> GetAllCompanies();
        void CreateCompany(CompanyDto companyDto);
        void DeleteCompany(int id);
        void UpdateCompany(CompanyDto companyDto);
    }
}
