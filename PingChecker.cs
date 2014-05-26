using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
namespace MyChecker
{
    class PingChecker:IChecker
    {
        private String _destination;
        
        public PingChecker(String HostNameOrAddress)
        {
            _destination = HostNameOrAddress;
        }
        public CheckResult Check()
        {
            CheckResult Result = new CheckResult();
            Result.Message = String.Format("{0}\n Ping to:{1} is OK.",
                this.GetType().ToString() , _destination);
            Result.Status = ResultStatus.OK ;

            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(_destination);

                if (reply.Status != IPStatus.Success)
                {
                    Result.Message = String.Format("{0}\n Ping to:{1} failed.\n PingReply status:{2}.",
                this.GetType().ToString() , _destination , reply.Status);
                    Result.Status = ResultStatus.ERR;
                }
            }
            catch (Exception ex)
            {
                Result.Message = String.Format("{0}\n Ping to:{1} get an exception:{2}",
                this.GetType().ToString() , _destination , ex.Message);
                Result.Status = ResultStatus.WARNING;
            }

           
            return Result;
        }
    }
}
