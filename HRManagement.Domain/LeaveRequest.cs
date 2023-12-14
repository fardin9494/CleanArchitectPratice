using HRManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Domain
{
    public class LeaveRequest:BaseDomainEntity
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime ActionDate { get; set; }

        public string RequestDiscription { get; set; }

        public LeaveType Type { get; set; }

        public int LeaveTypeId { get; set; }

        public bool? IsAproved { get; set; }

        public bool IsCancelled { get; set; }

    }
}
