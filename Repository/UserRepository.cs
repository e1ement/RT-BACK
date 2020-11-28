using Contracts;
using Entities;
using Entities.Dto;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await FindAll(false)
                .Include(i => i.Tasks)
                .ThenInclude(ti => ti.Task)
                .ThenInclude(ti => ti.Category)
                .Include(i => i.Tasks)
                .ThenInclude(ti => ti.Task)
                .ThenInclude(ti => ti.Dialogs)
                .ToListAsync();

            return users.Select(s => new UserDto(s));
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            var entity = await FindByCondition(x => x.Id == userId, false)
                .Include(i => i.Tasks)
                .ThenInclude(ti => ti.Task)
                .ThenInclude(ti => ti.Category)
                .Include(i => i.Tasks)
                .ThenInclude(ti => ti.Task)
                .ThenInclude(ti => ti.Dialogs)
                .FirstOrDefaultAsync();

            return new UserDto(entity);
        }

        public async Task<UserTaskDto> GetTaskByIdAndUserIdAsync(int taskId, int userId)
        {
            var entity = await FindByCondition(x => x.Id == userId, false)
                .Include(i => i.Tasks)
                .ThenInclude(ti => ti.Task)
                .ThenInclude(ti => ti.Category)
                .Include(i => i.Tasks)
                .ThenInclude(ti => ti.Task)
                .ThenInclude(ti => ti.Dialogs)
                .FirstOrDefaultAsync();
            var task = entity.Tasks.FirstOrDefault(x => x.TaskId == taskId);

            return new UserTaskDto(task);
        }
    }
}
