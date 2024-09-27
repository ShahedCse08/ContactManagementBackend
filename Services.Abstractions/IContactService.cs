
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<(IEnumerable<ContactDto>, int)> GetAllAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<(IEnumerable<ContactDto>, int)> GetAllAsync(string? searchTerm,int pageIndex, int pageSize, CancellationToken cancellationToken = default);

        Task<ContactDto> GetByIdAsync(int contactId, CancellationToken cancellationToken = default);

        Task<ContactDto> CreateAsync(ContactForCreationDto contactForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(int contactId, ContactForUpdateDto contactForUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int contactId, CancellationToken cancellationToken = default);
    }
}
