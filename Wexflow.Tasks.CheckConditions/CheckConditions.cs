using Contract;
using System;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.CheckConditions
{
    public class CheckConditions : Task
    {
        static long _userId;
        static TimeSpan _interval;

        public CheckConditions(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("userId")))
                _userId = long.Parse(GetSetting("userId"));

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
                    // 
                    return new TaskStatus(Status.Success, true);
                }
                else
                {
                    // TODO SET USERID
                    return new TaskStatus(Status.Error, false);
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
