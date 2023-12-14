using HRManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveAllocationDtos
{
    internal class CreateLeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
