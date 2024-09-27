using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ContactsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contactsDto = await _serviceManager.ContactService.GetAllAsync();

            return Ok(contactsDto);
        }

        [HttpGet("GetPaginatedContacts")]
        public async Task<IActionResult> GetContacts([FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            var (contactsDto, totalContacts) = await _serviceManager.ContactService.GetAllAsync(pageIndex, pageSize);

            return Ok(new { Contacts = contactsDto, TotalContacts = totalContacts });
        }


        [HttpGet("GetPaginatedAndSearchableContacts")]
        public async Task<IActionResult> GetContacts([FromQuery] string? searchTerm , [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            var (contactsDto, totalContacts) = await _serviceManager.ContactService.GetAllAsync(searchTerm,pageIndex, pageSize);

            return Ok(new { Contacts = contactsDto, TotalContacts = totalContacts });
        }


        [HttpGet("{contactId:int}")]
        public async Task<IActionResult> GetContactById(int contactId)
        {
            var contactDto = await _serviceManager.ContactService.GetByIdAsync(contactId);

            return Ok(contactDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactForCreationDto contactForCreationDto, CancellationToken cancellationToken)
        {
            var contactDto = await _serviceManager.ContactService.CreateAsync(contactForCreationDto);

            return CreatedAtAction(nameof(GetContactById), new {  contactId = contactDto.Id }, contactDto);
        }


        [HttpPut("{contactId:int}")]
        public async Task<IActionResult> UpdateContact(int contactId, [FromBody] ContactForUpdateDto contactForUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.ContactService.UpdateAsync(contactId, contactForUpdateDto, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{contactId:int}")]
        public async Task<IActionResult> DeleteContact(int contactId, CancellationToken cancellationToken)
        {
            await _serviceManager.ContactService.DeleteAsync(contactId, cancellationToken);
            return NoContent();
        }
    }
}
