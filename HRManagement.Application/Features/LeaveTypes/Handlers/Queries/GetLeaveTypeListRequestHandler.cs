using AutoMapper;
using HRManagement.Application.DTOs.LeaveTypeDtos;
using HRManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRManagement.Application.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    internal class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypesListRequest, List<LeaveTypeDto>>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;

        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }
    }
}
