using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class ContactRepository : IContactRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ContactRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default) =>
           await _dbContext.Contacts.Include(x => x.Group).ToListAsync(cancellationToken);

        public async Task<(IEnumerable<Contact>, int)> GetAllAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var totalRecords = await _dbContext.Contacts.CountAsync(cancellationToken);
            var contacts = await _dbContext.Contacts
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).Include(x => x.Group)
                .ToListAsync(cancellationToken);

            return (contacts, totalRecords);
        }

        public async Task<(IEnumerable<Contact>, int)> GetAllAsync(string? searchTerm, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Contacts.Include(x => x.Group).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(c => c.Name.Contains(searchTerm) || c.PhoneNumber.Contains(searchTerm));
            }

            var totalRecords = await query.CountAsync(cancellationToken);

            var contacts = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return (contacts, totalRecords);
        }



        public async Task<Contact> GetByIdAsync(int contactId, CancellationToken cancellationToken = default) =>
            await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == contactId, cancellationToken);

        public void Insert(Contact contact) => _dbContext.Contacts.Add(contact);

        public void Remove(Contact contact) => _dbContext.Contacts.Remove(contact);
    }
}
