using HRManagement.Application.DTOs.LeaveTypeDtos;
using HRManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRManagement.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrMangement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _madiat;

        public LeaveTypeController(IMediator madiat)
        {
            _madiat = madiat;
        }


        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> GetAsync()
        {
            var LeaveTypes = await _madiat.Send(new GetLeaveTypesListRequest());
            return Ok(LeaveTypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var LeaveType = await _madiat.Send(new GetLeaveTypeDetailsRequest { Id = id });
            return Ok(LeaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var command =  new CreateLeaveTypeCommand{ leaveTypeDto  = leaveType };
            var response = await _madiat.Send(command);
            return Ok(response);

        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LeaveTypeDto leaveType)
        {
            var command = new UpdateLeaveTypeCommand { leaveTypeDto = leaveType };
            await _madiat.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _madiat.Send(command);
            return NoContent();
        }
    }
}
