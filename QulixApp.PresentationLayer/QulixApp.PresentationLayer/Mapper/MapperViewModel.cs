using QulixApp.BusinessLogicLayer.DtoModels;
using QulixApp.PresentationLayer.Models;

namespace QulixApp.PresentationLayer.Mapper
{
    public static class MapperViewModel
    {
        public static CompanyViewModel Map(CompanyDto from)
        {
            var CompanyViewModel = new CompanyViewModel()
            {
                Id = from.Id,
                Name = from.Name,
                OrganizationalForm = from.OrganizationalForm
            };
            return CompanyViewModel;
        }

        public static CompanyDto Map(CompanyViewModel from)
        {
            var CompanyDto = new CompanyDto()
            {
                Id = from.Id,
                Name = from.Name,
                OrganizationalForm = from.OrganizationalForm
            };
            return CompanyDto;
        }

        public static EmployeeViewModel Map(EmployeeDto from)
        {
            var employeeViewModel = new EmployeeViewModel()
            {
                Id = from.Id,
                LastName = from.LastName,
                FirstName = from.FirstName,
                Patronymic = from.Patronymic,
                Position = from.Position,
                EmploymentDate = from.EmploymentDate,
                CompanyId = from.CompanyId,
                CompanyName = from.CompName
            };
            return employeeViewModel;
        }

        public static EmployeeDto Map(EmployeeViewModel from)
        {
            var EmployeeDto = new EmployeeDto()
            {
                Id = from.Id,
                LastName = from.LastName,
                FirstName = from.FirstName,
                Patronymic = from.Patronymic,
                Position = from.Position,
                EmploymentDate = from.EmploymentDate,
                CompanyId = from.CompanyId,
                CompName = from.CompanyName
            };
            return EmployeeDto;
        }
    }
}
