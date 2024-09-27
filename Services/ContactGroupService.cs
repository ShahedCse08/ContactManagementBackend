using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repository;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class ContactGroupService : IContactGroupService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ContactGroupService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<ContactGroupDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var groups = await _repositoryManager.ContactGroupRepository.GetAllAsync(cancellationToken);

            return groups.Adapt<IEnumerable<ContactGroupDto>>();
        }

        public async Task<ContactGroupDto> GetByIdAsync(int groupId, CancellationToken cancellationToken = default)
        {
            var group = await _repositoryManager.ContactGroupRepository.GetByIdAsync(groupId, cancellationToken);

            if (group is null)
            {
                throw new ContactGroupNotFoundException(groupId);
            }

            return group.Adapt<ContactGroupDto>();
        }

        public async Task<ContactGroupDto> CreateAsync(ContactGroupForCreationDto contactGroupForCreationDto, CancellationToken cancellationToken = default)
        {
            var group = contactGroupForCreationDto.Adapt<ContactGroup>();

            _repositoryManager.ContactGroupRepository.Insert(group);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return group.Adapt<ContactGroupDto>();
        }

        public async Task DeleteAsync(int groupId, CancellationToken cancellationToken = default)
        {
            var group = await _repositoryManager.ContactGroupRepository.GetByIdAsync(groupId, cancellationToken);

            if (group is null)
            {
                throw new ContactGroupNotFoundException(groupId);
            }

            _repositoryManager.ContactGroupRepository.Remove(group);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
