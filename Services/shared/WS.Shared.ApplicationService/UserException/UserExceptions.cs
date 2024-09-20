using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Shared.ApplicationService.UserException
{
    public class UserExceptions : Exception
    {
        public UserExceptions(string mesage) : base(mesage) { }

    }
}
