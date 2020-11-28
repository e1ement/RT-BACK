using Entities.Models;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFtpSettingsRepository
    {
        Task<FtpSettingsEntity> GetLastActiveAsync();
        Task<int> CreateAsync(FtpSettingsEntity entity);
    }
}
