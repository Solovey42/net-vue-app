using Microsoft.Extensions.Hosting;

namespace API.Domain.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; } = new List<Employee>();
    }
}
