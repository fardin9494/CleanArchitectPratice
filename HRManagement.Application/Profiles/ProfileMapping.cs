using AutoMapper;
using HRManagement.Application.DTOs.LeaveAllocationDtos;
using HRManagement.Application.DTOs.LeaveRequestDtos;
using HRManagement.Application.DTOs.LeaveTypeDtos;
using HRManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Profiles
{
    internal class ProfileMapping : Profile
    {
        public ProfileMapping() {

            CreateMap<LeaveAllocation , LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType , LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveRequest , LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest , LeaveRequestListDto>().ReverseMap();
        
        }
    }
}
