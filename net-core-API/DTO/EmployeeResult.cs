using System;

namespace API.DTO
{
    public class EmployeeResult
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public double Salary { get; set; }

        public string DepartmentName { get; set; }
    }
}
