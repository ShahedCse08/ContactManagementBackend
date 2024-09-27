using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepositoryManager
    {
        IContactRepository ContactRepository { get; }

        IContactGroupRepository ContactGroupRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
