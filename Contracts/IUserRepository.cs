using Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int userId);
        Task<UserTaskDto> GetTaskByIdAndUserIdAsync(int taskId, int userId);
    }
}
