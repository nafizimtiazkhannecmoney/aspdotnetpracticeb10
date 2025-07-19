using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Singleton
{
    internal class Logger
    {
        private static Logger _logger;
        private Logger()
        {
                
        }
        public static Logger Instance
        {
            get
            {
                if(_logger == null)
                    _logger = new Logger();
                return _logger;
            }
        }
    }
}
 