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
    public class ProfileMapping : Profile
    {
        public ProfileMapping() {
            #region leaveallocation
            CreateMap<LeaveAllocation , LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation , CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation , UpdateLeaveAllocationDto>().ReverseMap();
            #endregion

            #region leaveRequest
            CreateMap<LeaveRequest , LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest , LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest , CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest , UpdateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest , ChangeLeaveRequestAprovealDto>().ReverseMap();
            #endregion

            #region LeaveType
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            #endregion
        }
    }
}
