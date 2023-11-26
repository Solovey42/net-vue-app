using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.DTO;

namespace API.Domain.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentResult>> DepartmentListAsync();
    }
}
