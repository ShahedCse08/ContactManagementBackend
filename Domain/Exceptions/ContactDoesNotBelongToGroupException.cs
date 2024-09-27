using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ContactDoesNotBelongToGroupException : BadRequestException
    {
        public ContactDoesNotBelongToGroupException(int groupId, int contactId)
            : base($"The contact with the identifier {contactId} does not belong to the group with the identifier {groupId}.")
        {
        }
    }
}
