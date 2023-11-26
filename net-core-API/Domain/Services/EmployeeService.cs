using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.DTO;

namespace API.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(IEmployeeRepository linkRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = linkRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Employee>> EmployeeListAsync()
        {
            return await _employeeRepository.EmployeeListAsync();
        }

        public async Task<Employee> EmployeeGetByIdAsync(int id)
        {
            return await _employeeRepository.EmployeeGetByIdAsync(id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            if (employee != null)
            {
                return await _employeeRepository.CreateEmployeeAsync(employee);
            }
            else
            {
                return null;
            }
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            if (employee != null)
            {
                return await _employeeRepository.UpdateEmployeeAsync(employee);
            }
            else
            {
                return null;
            }
        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            return await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
