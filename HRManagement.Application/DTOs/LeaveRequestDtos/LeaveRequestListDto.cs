﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveRequestDtos
{
    internal class LeaveRequestListDto
    {
        public DateTime RequestDate { get; set; }

        public LeaveTypeDto Type { get; set; }

        public bool? IsAproved { get; set; }

    }
}
