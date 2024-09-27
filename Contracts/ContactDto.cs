
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactType { get; set; }
        public int? GroupId { get; set; }  // Nullable if the contact doesn't belong to a group
        public string GroupName { get; set; }  // For easy retrieval of the group name
    }

}
