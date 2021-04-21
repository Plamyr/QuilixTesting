using QulixApp.BusinessLogicLayer.DtoModels;
using QulixApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QulixApp.BusinessLogicLayer.Mapper
{
    public static class MapperClass
    {
        public static EmployeeDto Map(Employee from)
        {
            var EmployeeDto = new EmployeeDto()
            {
                Id = from.Id,
                LastName = from.LastName,
                FirstName = from.FirstName,
                Patronymic = from.Patronymic,
                Position = from.Position,
                EmploymentDate = from.EmploymentDate,
                CompanyId = from.CompanyId
            };
            return EmployeeDto;            
        }

        public static CompanyDto Map(Company from)
        {
            var CompanyDto = new CompanyDto()
            {
                Id = from.Id,
                Name = from.Name,
                OrganizationalForm = from.OrganizationalForm
            };
            return CompanyDto;
        }
    }
}
