using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ContactForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(12, ErrorMessage = "Phone number can't be longer than 12 characters")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Contact type is required")]
        [StringLength(10, ErrorMessage = "Contact type can't be longer than 10 characters")]
        public string ContactType { get; set; }

        [Required(ErrorMessage = "Contact group is required")]
        public int GroupId { get; set; }  
    }
}
