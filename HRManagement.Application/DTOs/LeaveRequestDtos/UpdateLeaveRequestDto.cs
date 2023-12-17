using HRManagement.Application.DTOs.Common;
using HRManagement.Application.DTOs.LeaveTypeDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveRequestDtos
{
    public class UpdateLeaveRequestDto : BaseDto,IleaveRequestDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string RequestDiscription { get; set; }

        public int LeaveTypeId { get; set; }

        public bool IsCancelled { get; set; }

    }
}
