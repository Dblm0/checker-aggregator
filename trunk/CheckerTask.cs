using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace MyChecker
{
    class CheckerTask
    {
        private int _delayinsec;
        private IChecker _checker;
        private Task<CheckResult> _task;

        public String CheckerType
        {
            get {return _checker.ToString(); }
        }
        public TaskStatus Status
        {
            get { return _task.Status; }
        }
        public CheckerTask(IChecker Checker,int DelayInSec)
        {
            _delayinsec = DelayInSec;
            _checker = Checker;
        }
        private CheckResult CheckerCycle()
        {
            CheckResult Result = new CheckResult();
            Result.Status = ResultStatus.OK;
            Result.Message = String.Empty;
            
            while (true)
            {
                Result = _checker.Check();
                if (Result.Status != ResultStatus.OK)
                    return Result;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}\n", Result.Message);
                Console.ResetColor();
                
                Thread.Sleep(TimeSpan.FromSeconds(_delayinsec));
            }
        }
        public void Run()
        {
            _task = new Task<CheckResult>(() => CheckerCycle());
            _task.Start();
        }
        public CheckResult GetResult()
        {
            return _task.Result;
        }
    }
}
