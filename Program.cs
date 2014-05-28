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

            List<CheckerTask> CheckerTasks = new List<CheckerTask>();
            CheckerTasks.Add(new CheckerTask(new PingChecker("codeproject.com"),5));
            CheckerTasks.Add(new CheckerTask(new PingChecker("vk.com"), 2));
            CheckerTasks.Add(new CheckerTask(new FreeSpaceChecker("C"), 3));

            CheckerAggregator Aggregator = new CheckerAggregator(CheckerTasks, Sender);
            Aggregator.Run();
        }
    }
}
