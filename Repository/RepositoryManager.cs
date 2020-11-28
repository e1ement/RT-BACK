using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        private IValueRepository _valueRepository;
        private IFtpSettingsRepository _ftpSettingsRepository;
        private ITaskRepository _taskRepository;
        private IUserRepository _userRepository;
        private IDialogRepository _dialogRepository;

        public IValueRepository ValueRepository =>
            _valueRepository ??= new ValueRepository(_repositoryContext);

        public IFtpSettingsRepository FtpSettingsRepository =>
            _ftpSettingsRepository ??= new FtpSettingsRepository(_repositoryContext);

        public ITaskRepository TaskRepository =>
            _taskRepository ??= new TaskRepository(_repositoryContext);

        public IUserRepository UserRepository =>
            _userRepository ??= new UserRepository(_repositoryContext);

        public IDialogRepository DialogRepository =>
            _dialogRepository ??= new DialogRepository(_repositoryContext);
    }
}
