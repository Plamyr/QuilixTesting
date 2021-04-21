using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QulixApp.PresentationLayer.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Position { get; set; }
        public DateTime EmploymentDate { get; set; }

        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
    }
}
