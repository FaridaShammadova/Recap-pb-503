using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap
{
    public class NotInvalidException:Exception
    {
        public NotInvalidException()
        {
        }

        public NotInvalidException(string? message):base(message)
        {
        }
    }
}
