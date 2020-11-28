using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository
{
    public class FtpSettingsRepository : RepositoryBase<FtpSettingsEntity>, IFtpSettingsRepository
    {
        public FtpSettingsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<FtpSettingsEntity> GetLastActiveAsync()
        {
            return await FindByCondition(x => !x.IsDeleted, false)
                .LastOrDefaultAsync();
        }

        public async Task<int> CreateAsync(FtpSettingsEntity entity)
        {
            await Create(entity);
            return await SaveChanges();
        }
    }
}
