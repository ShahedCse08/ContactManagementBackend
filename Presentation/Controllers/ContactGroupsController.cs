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
    [Route("api/contactgroups")]
    public class ContactGroupsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ContactGroupsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetContactGroups(CancellationToken cancellationToken)
        {
            var groupsDto = await _serviceManager.ContactGroupService.GetAllAsync(cancellationToken);

            return Ok(groupsDto);
        }

        [HttpGet("{groupId:int}")]
        public async Task<IActionResult> GetContactGroupById(int groupId, CancellationToken cancellationToken)
        {
            var groupDto = await _serviceManager.ContactGroupService.GetByIdAsync(groupId, cancellationToken);

            return Ok(groupDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactGroup([FromBody] ContactGroupForCreationDto contactGroupForCreationDto, CancellationToken cancellationToken)
        {
            var response = await _serviceManager.ContactGroupService.CreateAsync(contactGroupForCreationDto, cancellationToken);

            return CreatedAtAction(nameof(GetContactGroupById), new { groupId = response.Id }, response);
        }

        [HttpDelete("{groupId:int}")]
        public async Task<IActionResult> DeleteContactGroup(int groupId, CancellationToken cancellationToken)
        {
            await _serviceManager.ContactGroupService.DeleteAsync(groupId, cancellationToken);

            return NoContent();
        }
    }
}
