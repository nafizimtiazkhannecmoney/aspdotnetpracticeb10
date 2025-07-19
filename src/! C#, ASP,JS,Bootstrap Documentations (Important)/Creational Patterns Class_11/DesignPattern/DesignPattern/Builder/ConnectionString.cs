using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder
{
    internal class ConnectionString
    {

        public StringBuilder ConnectionStrinItem { get; set; }
        public ConnectionString()
        {
            ConnectionStrinItem = new StringBuilder();
        }
    }
}
