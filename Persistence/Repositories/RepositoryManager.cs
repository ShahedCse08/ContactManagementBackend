
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IContactRepository> _lazyContactRepository;
        private readonly Lazy<IContactGroupRepository> _lazyContactGroupRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyContactRepository = new Lazy<IContactRepository>(() => new ContactRepository(dbContext));
            _lazyContactGroupRepository = new Lazy<IContactGroupRepository>(() => new ContactGroupRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IContactRepository ContactRepository => _lazyContactRepository.Value;

        public IContactGroupRepository ContactGroupRepository => _lazyContactGroupRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
