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
    internal sealed class ContactGroupRepository : IContactGroupRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ContactGroupRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<ContactGroup>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.ContactGroups.ToListAsync(cancellationToken);

        public async Task<ContactGroup> GetByIdAsync(int groupId, CancellationToken cancellationToken = default) =>
            await _dbContext.ContactGroups.FirstOrDefaultAsync(x => x.Id == groupId, cancellationToken);

        public void Insert(ContactGroup group) => _dbContext.ContactGroups.Add(group);

        public void Remove(ContactGroup group) => _dbContext.ContactGroups.Remove(group);
    }
}
