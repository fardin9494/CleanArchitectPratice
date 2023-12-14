using HRManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveTypeDtos
{
    public class LeaveTypeDto : BaseDto
    {
        public string Name { get; set; }

        public int DeafultDay { get; set; }
    }
}
