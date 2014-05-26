using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MyChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailSender Sender = new EmailSender();
            
            List<IChecker> Checkers = new List<IChecker>();
            Checkers.Add(new PingChecker("codeproject.com"));
            Checkers.Add(new FreeSpaceChecker("C"));

            CheckerAggregator Aggregator = new CheckerAggregator(Checkers, Sender);
            Aggregator.Run();
        }
    }
}
