using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IContactGroupService
    {
        Task<IEnumerable<ContactGroupDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ContactGroupDto> GetByIdAsync(int groupId, CancellationToken cancellationToken = default);

        Task<ContactGroupDto> CreateAsync(ContactGroupForCreationDto contactGroupForCreationDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int groupId, CancellationToken cancellationToken = default);
    }
}
