using HRManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveRequestDtos
{
    public class ChangeLeaveRequestAprovealDto : BaseDto
    {
        public bool? IsAproved { get; set; }
    }
}
