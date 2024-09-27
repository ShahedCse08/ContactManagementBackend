using Domain.Repository;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IContactService> _lazyContactService;
        private readonly Lazy<IContactGroupService> _lazyContactGroupService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyContactService = new Lazy<IContactService>(() => new ContactService(repositoryManager));
            _lazyContactGroupService = new Lazy<IContactGroupService>(() => new ContactGroupService(repositoryManager));
        }

        public IContactService ContactService => _lazyContactService.Value;

        public IContactGroupService ContactGroupService => _lazyContactGroupService.Value;
    }
}
