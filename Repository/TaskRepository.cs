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
    public class TaskRepository : RepositoryBase<TaskEntity>, ITaskRepository
    {
        public TaskRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            var entities = await FindAll(false)
                .Include(i => i.Category)
                .ToListAsync();

            return entities.Select(s => new TaskDto(s));
        }

        public async Task<TaskDto> GetByIdAsync(int id)
        {
            var entity = await FindByCondition(x => x.Id == id, false)
                .Include(i => i.Category)
                .FirstOrDefaultAsync();

            return new TaskDto(entity);
        }
    }
}
