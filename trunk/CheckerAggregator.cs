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

        public void Exec()
        {
            List<Task<CheckResult>> TaskList = new List<Task<CheckResult>>();
            foreach (CheckerTask CT in _checkertasks)
            {
                CT.Run();
            }

            while (true)
            {
                foreach (CheckerTask CT in _checkertasks)
                {
                    if (CT.Status != TaskStatus.RanToCompletion)
                        continue;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Checker :{0} Failed \n Sending report...\n ",CT.CheckerType);
                        Console.ResetColor();

                        _sender.SendMsg(CT.GetResult().Message);
                        CT.Run();
                    }
                        
                }
            }
        }
    }
}
