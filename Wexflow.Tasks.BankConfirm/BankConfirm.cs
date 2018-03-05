using Contract;
using System;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.BankConfirm
{
    public class BankConfirm : Task
    {
        static TimeSpan _interval;
        public BankConfirm(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("interval")))
                _interval = TimeSpan.Parse(GetSetting("interval"));
        }

        public override TaskStatus Run(RequestModel model = null)
        {
            // TODO EXCEPTION HANDLING.
            // TODO IMPLEMENT WEB SERVICES TO GET CONDITION RESULT.
            var serviceResult = true;

            while (true)
            {
                if (serviceResult)
                {
                    // CheckConditions
                    return new TaskStatus(Status.Success);
                }
                else
                {
                    // فراخوانی سرویس لغو درخواست
                    return new TaskStatus(Status.Error);
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
