using HRManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveRequestDtos
{
    internal class UpdateLeaveRequestDto : BaseDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string RequestDiscription { get; set; }

        public int LeaveTypeId { get; set; }

        public bool IsCancelled { get; set; }
    }
}
