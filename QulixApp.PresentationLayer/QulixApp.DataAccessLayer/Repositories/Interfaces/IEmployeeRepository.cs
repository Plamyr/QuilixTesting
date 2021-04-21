using QulixApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace QulixApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        void AddEmployee(string lastNane, string firstName, DateTime date,string patronymic, string position, int companyId);
        void UpdateEmployee(int id, string lastNane, string firstName, string patronymic, string position,DateTime date, int companyId);
        void DeleteEmployee(int id);
        Employee ReadEmployee(int id);
        List<Employee> ReadAll();
    }
}
