﻿using AutoMapper;
using HRManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRManagement.Application.Persistence.Cortract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    internal class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var SelectedAllocation = await _leaveAllocationRepository.GetById(request.leaveAllocationDto.Id);
            _mapper.Map(request.leaveAllocationDto,SelectedAllocation);
            await _leaveAllocationRepository.Update(SelectedAllocation);
            
            return Unit.Value;
        }
    }
}
