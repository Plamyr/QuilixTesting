using QulixApp.BusinessLogicLayer.DtoModels;
using System.Collections.Generic;

namespace QulixApp.BusinessLogicLayer.Services.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeDto employeeDto);
        void UpdateEmployee(EmployeeDto employeeDto);
        void DeleteEmployee(int id);
        EmployeeDto GetEmployee(int id);
        List<EmployeeDto> GetAllEmployees();
    }
}
