using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }

}
