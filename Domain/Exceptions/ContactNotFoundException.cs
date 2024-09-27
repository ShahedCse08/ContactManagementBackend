
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ContactNotFoundException : NotFoundException
    {
        public ContactNotFoundException(int contactId)
            : base($"The contact with the identifier {contactId} was not found.")
        {
        }
    }
}
