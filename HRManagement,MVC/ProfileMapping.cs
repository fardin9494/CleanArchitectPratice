using AutoMapper;
using HRManagement.MVC.Models;
using HRManagement.MVC.Services.Base;

namespace HRManagement.MVC
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto,LeaveTypeVM>().ReverseMap();
        }
    }
}
