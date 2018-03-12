using Contract;
using System;
using System.Threading;
using System.Xml.Linq;
using WebService;
using Wexflow.Core;

namespace Wexflow.Tasks.BankConfirm
{
    public class BankConfirm : Task
    {
        static TimeSpan _interval;
        static long _userId;

        public BankConfirm(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("interval")))
                _interval = TimeSpan.Parse(GetSetting("interval"));

            if (!string.IsNullOrWhiteSpace(GetSetting("userId")))
                _userId = long.Parse(GetSetting("userId"));
        }

        public override TaskStatus Run(RequestModel model = null)
        {
            // TODO EXCEPTION HANDLING.
            // TODO IMPLEMENT WEB SERVICES TO GET CONDITION RESULT.
            new ServiceProxy().ForwardService(_userId,2,1);
            var serviceResult = true;
            model.UserId = 0;
            while (true)
            {
                if (serviceResult)
                {
                    return new TaskStatus(Status.Success, true);
                }
                else
                {
                    // فراخوانی سرویس لغو درخواست
                    return new TaskStatus(Status.Error, false);
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
