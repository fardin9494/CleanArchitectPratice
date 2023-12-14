using HRManagement.Application.DTOs.Common;
using HRManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveRequestDtos
{
    public class LeaveRequestDto : BaseDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime ActionDate { get; set; }

        public string RequestDiscription { get; set; }

        public LeaveTypeDto Type { get; set; }

        public int LeaveTypeId { get; set; }

        public bool? IsAproved { get; set; }

        public bool IsCancelled { get; set; }
    }
}
