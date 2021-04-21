using QulixApp.BusinessLogicLayer.DtoModels;
using QulixApp.BusinessLogicLayer.Mapper;
using QulixApp.BusinessLogicLayer.Services.Interfaces;
using QulixApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;

namespace QulixApp.BusinessLogicLayer.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            _employeeRepository.AddEmployee(employeeDto.LastName, employeeDto.FirstName, employeeDto.EmploymentDate,employeeDto.Patronymic,employeeDto.Position, employeeDto.CompanyId);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            var employeeEntities = _employeeRepository.ReadAll();
            var listOfEmployees = new List<EmployeeDto>();
            foreach (var item in employeeEntities)
            {
                var company = _companyRepository.ReadCompany(item.CompanyId);
                var dtoModel = MapperClass.Map(item);
                dtoModel.CompName = company.Name;
                listOfEmployees.Add(dtoModel);
            }
            return listOfEmployees;
        }

        public EmployeeDto GetEmployee(int id)
        {
            var entity = _employeeRepository.ReadEmployee(id);
            var employeeDto = MapperClass.Map(entity);
            return employeeDto;
        }

        public void UpdateEmployee(EmployeeDto employeeDto)
        {
            _employeeRepository.UpdateEmployee(employeeDto.Id, employeeDto.LastName, employeeDto.FirstName,employeeDto.Patronymic,employeeDto.Position, employeeDto.EmploymentDate, employeeDto.CompanyId);
        }
    }
}
