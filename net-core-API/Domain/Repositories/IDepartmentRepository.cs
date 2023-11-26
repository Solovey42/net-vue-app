using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> DepartmentListAsync();

        Task<Department> DepartmentGetByIdAsync(int id);
    }
}
