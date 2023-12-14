using HRManagement.Application.DTOs.Common;
using HRManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }

        public LeaveTypeDto Type { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
