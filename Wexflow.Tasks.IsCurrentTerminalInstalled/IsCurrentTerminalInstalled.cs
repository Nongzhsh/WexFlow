using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.IsCurrentTerminalInstalled
{
    public class IsCurrentTerminalInstalled : Task
    {
        static TimeSpan _interval;
        static long _userId;
        public IsCurrentTerminalInstalled(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("interval")))
                _interval = TimeSpan.Parse(GetSetting("interval"));

            if (!string.IsNullOrWhiteSpace(GetSetting("userId")))
                _userId = long.Parse(GetSetting("userId"));
        }

        public override TaskStatus Run(RequestModel model = null)
        {
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
                    // تایید ابطال
                    // CheckForBeingNewMarketing
                    return new TaskStatus(Status.Error);
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
