﻿using HRManagement.Application.DTOs.Common;
using HRManagement.Application.DTOs.LeaveTypeDtos;
using HRManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveAllocationDtos
{
    public class LeaveAllocationDto : BaseDto,ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }

        public LeaveTypeDto Type { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
