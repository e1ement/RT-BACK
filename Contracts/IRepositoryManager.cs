namespace Contracts
{
    public interface IRepositoryManager
    {
        IValueRepository ValueRepository { get; }
        IFtpSettingsRepository FtpSettingsRepository { get; }
        ITaskRepository TaskRepository { get; }
        IUserRepository UserRepository { get; }
        IDialogRepository DialogRepository { get; }
    }
}
