using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHealthCheckFormStatusChecker
{
    public class InputOutputModel
    {
        public class InputModel
        {
            public string TicketId { get; set; }
        }

        public class OutputModel
        {
            public string Status { get; set; }
        }

    }
}
