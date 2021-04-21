using QulixApp.BusinessLogicLayer.DtoModels;
using QulixApp.BusinessLogicLayer.Mapper;
using QulixApp.BusinessLogicLayer.Services.Interfaces;
using QulixApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;

namespace QulixApp.BusinessLogicLayer.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void CreateCompany(CompanyDto companyDto)
        {
            _companyRepository.AddCompany(companyDto.Name, companyDto.OrganizationalForm);
        }

        public void DeleteCompany(int id)
        {
            _companyRepository.DeleteCompany(id);
        }

        public List<CompanyDto> GetAllCompanies()
        {
            var companyEntities = _companyRepository.ReadAll();
            var listOfCompanies = new List<CompanyDto>();
            foreach(var item in companyEntities)
            {
                listOfCompanies.Add(MapperClass.Map(item));
            }
            return listOfCompanies;
        }

        public CompanyDto GetCompany(int id)
        {
            var entity = _companyRepository.ReadCompany(id);
            var companyDto = MapperClass.Map(entity);
            return companyDto;
        }

        public void UpdateCompany(CompanyDto companyDto)
        {
            _companyRepository.UpdateCompany(companyDto.Id, companyDto.Name, companyDto.OrganizationalForm);
        }
    }
}
