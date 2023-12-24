﻿using AutoMapper;
using HRManagement.Application.DTOs.LeaveAllocationDtos;
using HRManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HRManagement.Application.Contract.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    internal class GetLeaveAllocationListRequesthandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequesthandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _leaveAllocationRepository.GetAll();
            return  _mapper.Map <List<LeaveAllocationDto>>(leaveAllocations);
        }
    }
}
