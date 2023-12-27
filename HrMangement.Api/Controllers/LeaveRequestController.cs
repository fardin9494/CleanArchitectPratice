using HRManagement.Application.DTOs.LeaveRequestDtos;
using HRManagement.Application.Features.LeaveRequests.Handlers.Commands;
using HRManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrMangement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _madiat;

        public LeaveRequestController(IMediator madiat)
        {
            _madiat = madiat;
        }


        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            var leaveRequests =await _madiat.Send(new GetLeaveRequestListRequest());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var leaveRequest = await _madiat.Send(new GetLeaveRequestDetailrequest { Id = id});
            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequest)
        {
            var command = new CreateLeaveRequestCommand { createLeaveRequest = leaveRequest };
            var response = await _madiat.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto updateLeaveRequest)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, updateleaveRequestDto = updateLeaveRequest };
            await _madiat.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _madiat.Send(command);
            return NoContent();
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("changeaproval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestAprovealDto changeLeaveRequestAproveal)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, changeLeaveRequestAproveal = changeLeaveRequestAproveal };
            await _madiat.Send(command);
            return NoContent();
        }

    }
}
