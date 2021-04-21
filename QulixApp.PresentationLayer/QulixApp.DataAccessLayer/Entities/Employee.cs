using System;

namespace QulixApp.DataAccessLayer.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Position { get; set; }
        public DateTime EmploymentDate { get; set; }

        public int CompanyId { get; set; }
        public int CompanyName { get; set; }
    }
}
