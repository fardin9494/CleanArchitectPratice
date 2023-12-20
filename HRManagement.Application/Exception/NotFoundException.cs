using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Exception
{
    internal class NotFoundException : ApplicationException
    {
        public NotFoundException(string name,object Key) : base($"{name} - ({Key}) Not Found")
        { 
        }
    }
}
