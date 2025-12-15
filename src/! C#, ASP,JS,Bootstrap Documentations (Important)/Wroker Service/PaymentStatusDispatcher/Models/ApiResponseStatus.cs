using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentStatusDispatcher.Models
{
    public class ApiResponseStatus
    {
        // Note: It's typically safest to map status codes/subcodes as strings

        public string code { get; set; }
        public string subCode { get; set; }
    }
}
