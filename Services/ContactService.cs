
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repository;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class ContactService : IContactService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ContactService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

     

        public async Task<IEnumerable<ContactDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var contacts = await _repositoryManager.ContactRepository.GetAllAsync(cancellationToken);

            var contactsDto = contacts.Select(contact => new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                ContactType = contact.ContactType,
                GroupId = contact.GroupId,
                GroupName = contact.Group.GroupName 
            }).OrderBy(x=>x.Name).ToList();

            return contactsDto;
        }

        public async Task<(IEnumerable<ContactDto>, int)> GetAllAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var (contacts, totalRecords) = await _repositoryManager.ContactRepository.GetAllAsync(pageIndex, pageSize, cancellationToken);

            var contactsDto = contacts.Select(contact => new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                ContactType = contact.ContactType,
                GroupId = contact.GroupId,
                GroupName = contact.Group.GroupName
            }).OrderBy(x => x.Name).ToList();

            return (contactsDto, totalRecords);
        }

        public async Task<(IEnumerable<ContactDto>, int)> GetAllAsync(string? searchTerm,int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var (contacts, totalRecords) = await _repositoryManager.ContactRepository.GetAllAsync(searchTerm,pageIndex, pageSize, cancellationToken);

            var contactsDto = contacts.Select(contact => new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                ContactType = contact.ContactType,
                GroupId = contact.GroupId,
                GroupName = contact.Group.GroupName
            }).OrderBy(x => x.Name).ToList();

            return (contactsDto, totalRecords);
        }

        public async Task<ContactDto> GetByIdAsync(int contactId, CancellationToken cancellationToken = default)
        {
            var contact = await _repositoryManager.ContactRepository.GetByIdAsync(contactId, cancellationToken);

            if (contact is null)
            {
                throw new ContactNotFoundException(contactId);
            }

            var contactDto = contact.Adapt<ContactDto>();

            return contactDto;
        }

        public async Task<ContactDto> CreateAsync(ContactForCreationDto contactForCreationDto, CancellationToken cancellationToken = default)
        {
            var contact = contactForCreationDto.Adapt<Contact>();

            _repositoryManager.ContactRepository.Insert(contact);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return contact.Adapt<ContactDto>();
        }

        public async Task UpdateAsync(int contactId, ContactForUpdateDto contactForUpdateDto, CancellationToken cancellationToken = default)
        {
           

            var contact = await _repositoryManager.ContactRepository.GetByIdAsync(contactId, cancellationToken);

            if (contact is null)
            {
                throw new ContactNotFoundException(contactId);
            }

            contact.Name = contactForUpdateDto.Name;
            contact.PhoneNumber = contactForUpdateDto.PhoneNumber;
            contact.ContactType = contactForUpdateDto.ContactType;
            contact.GroupId = contactForUpdateDto.GroupId;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int contactId, CancellationToken cancellationToken = default)
        {
            var contact = await _repositoryManager.ContactRepository.GetByIdAsync(contactId, cancellationToken);

            if (contact is null)
            {
                throw new ContactNotFoundException(contactId);
            }

            _repositoryManager.ContactRepository.Remove(contact);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

       
    }
}
