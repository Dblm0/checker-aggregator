using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChecker
{
    class CheckerAggregator
    {
        private List<CheckerTask> _checkertasks;
        private ISender _sender;
        public CheckerAggregator(List<CheckerTask> Checkers, ISender Sender)
        {
            _checkertasks = Checkers;
            _sender = Sender;
        }

        public void Run()
        {
            List<Task<CheckResult>> TaskList = new List<Task<CheckResult>>();
            String Message;
            foreach (CheckerTask CT in _checkertasks)
            {
                CT.Run();
            }

            foreach (CheckerTask CT in _checkertasks)
            {
               _sender.SendMsg(CT.GetResult().Message);
            }
        }
    }
}
