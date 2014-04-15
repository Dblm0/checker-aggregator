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
        ResultStatus Status;
        String Message;
    }
    
    
    interface IChecker
    {
        CheckResult Check();
    }
}
