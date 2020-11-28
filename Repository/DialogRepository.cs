using Contracts;
using Entities;
using Entities.Dto;
using Entities.Models;
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
            var entity = dialogMessage.ToEntity();
            await Create(entity);
            await SaveChanges();

            return entity.Id;
        }
    }
}
