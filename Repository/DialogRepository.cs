using Contracts;
using Entities;
using Entities.Dto;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class DialogRepository : RepositoryBase<DialogEntity>, IDialogRepository
    {
        public DialogRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<int> CreateAsync(DialogForAddDto dialogMessage)
        {
            foreach (var entity in dialogMessage.Messages
                .Select(message => message.ToEntity(dialogMessage.UserId, dialogMessage.TaskId)))
            {
                await Create(entity);
            }

            return await SaveChanges();
        }

        public async Task<DialogResultDto> GetDialogResultAsync(int userId, int taskId)
        {
            var entities = await FindByCondition(x => x.UserId == userId && x.TaskId == taskId, false)
                .Include(i => i.Task)
                .ToListAsync();

            return new DialogResultDto(entities.FirstOrDefault());
        }
    }
}
