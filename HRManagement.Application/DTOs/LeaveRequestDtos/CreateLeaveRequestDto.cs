using HRManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveRequestDtos
{
    public class CreateLeaveRequestDto : BaseDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RequestDate { get; set; }

        public string RequestDiscription { get; set; }

        public int LeaveTypeId { get; set; }
    }
}
