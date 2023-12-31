﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime ModificationDate { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
