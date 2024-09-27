
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ContactGroupNotFoundException : NotFoundException
    {
        public ContactGroupNotFoundException(int groupId)
            : base($"The contact group with the identifier {groupId} was not found.")
        {
        }
    }
}
