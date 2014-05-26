using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChecker
{
    class CheckerAggregator
    {
        private List<IChecker> _checkers;
        private ISender _sender;
        public CheckerAggregator(List<IChecker> Checkers, ISender Sender)
        {
            _checkers = Checkers;
            _sender = Sender;
        }

        public void Run()
        {
            List<Task<CheckResult>> TaskList = new List<Task<CheckResult>>();
            String Message;
            foreach (IChecker Checker in _checkers)
            {
                TaskList.Add(Task<CheckResult>.Factory.StartNew(() => Checker.Check()));

            }


            foreach (Task<CheckResult> Task in TaskList)
            {
                Message = Task.Result.Message;
                Console.WriteLine(Message);
            }
            
     

        }
    }
}
