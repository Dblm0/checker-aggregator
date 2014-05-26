using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyChecker
{
    enum ResultStatus
    {
        OK,
        ERR,
        WARNING
    }
    
    struct CheckResult
    {
       public ResultStatus Status;
       public String Message;
    }
    
    
    interface IChecker
    {
        CheckResult Check();
    }
}
