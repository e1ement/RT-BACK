using Entities.Dto;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDialogRepository
    {
        Task<int> CreateAsync(DialogForAddDto dialogMessage);
        Task<DialogResultDto> GetDialogResultAsync(int userId, int taskId);
    }
}
