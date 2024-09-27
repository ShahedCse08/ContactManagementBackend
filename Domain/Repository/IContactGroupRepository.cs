using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IContactGroupRepository
    {
        Task<IEnumerable<ContactGroup>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ContactGroup> GetByIdAsync(int groupId, CancellationToken cancellationToken = default);

        void Insert(ContactGroup group);

        void Remove(ContactGroup group);
    }
}
