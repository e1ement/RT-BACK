using Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskDto>> GetAllAsync();
        Task<TaskDto> GetByIdAsync(int id);
    }
}
