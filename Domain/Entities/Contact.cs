using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactType { get; set; }
        public int? GroupId { get; set; }
        public ContactGroup Group { get; set; }
    }

}
