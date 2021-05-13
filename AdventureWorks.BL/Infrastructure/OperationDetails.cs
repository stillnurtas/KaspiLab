using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BL.Infrastructure
{
    public class OperationDetails
    {
        public Statuses Status { get; private set; }
        public string Message { get; private set; }
        public string Action { get; private set; }

        public OperationDetails(Statuses status, string message, string action)
        {
            Status = status;
            Message = message;
            Action = action;
        }

        public enum Statuses
        {
            Success,
            Error
        }
    }
}
