using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Model
{
    public class EmailSetting
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }

        public string FromName { get; set; }
    }
}
