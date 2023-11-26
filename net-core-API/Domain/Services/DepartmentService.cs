using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Domain.Services;
using API.DTO;

namespace API.Domain.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentResult>> DepartmentListAsync()
        {
            List<Department> departments = (List<Department>)await _departmentRepository.DepartmentListAsync();

            return departments.Select(department => new DepartmentResult
            {
                Id = department.Id,

                Name = department.Name

            });
        }
    }
}
