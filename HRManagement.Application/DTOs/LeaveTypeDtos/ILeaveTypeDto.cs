using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.DTOs.LeaveTypeDtos
{
    public interface ILeaveRequestDto
    {
        public string Name { get; set; }

        public int DeafultDay { get; set; }
    }
}
