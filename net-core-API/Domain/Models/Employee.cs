using System;
using API.Domain.Models;

namespace API
{
    public class Employee
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public double Salary { get; set; }
    }
}
