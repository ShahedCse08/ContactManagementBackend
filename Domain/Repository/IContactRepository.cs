using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<(IEnumerable<Contact>, int)> GetAllAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<(IEnumerable<Contact>, int)> GetAllAsync(string? searchTerm,int pageIndex, int pageSize, CancellationToken cancellationToken = default);

        Task<Contact> GetByIdAsync(int contactId, CancellationToken cancellationToken = default);

        void Insert(Contact contact);

        void Remove(Contact contact);
    }
}
