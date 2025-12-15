using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentStatusDispatcher.Models
{
    public sealed class PaymentStatusRow
    {
        public string? EndToEndId { get; init; }
        public string? Status { get; init; }
        public int? TTID { get; init; }
    }

}
