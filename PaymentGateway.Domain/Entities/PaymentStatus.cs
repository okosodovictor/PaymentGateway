using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public enum PaymentStatus
    {
        Pending,
        Success,
        Failure,
    }
}
