using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.IsSystemOpenCode
{
    public class IsSystemOpenCode : Task
    {
        static TimeSpan _interval;
        static TimeSpan _callTime;
        public IsSystemOpenCode(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("callTime")))
                _callTime = TimeSpan.Parse(GetSetting("callTime"));

            if (!string.IsNullOrWhiteSpace(GetSetting("interval")))
                _interval = TimeSpan.Parse(GetSetting("interval"));
        }

        public override TaskStatus Run(RequestModel model = null)
        {
            var serviceResult = true;
            var now = DateTime.Now;

            while (true)
            {
                if (serviceResult)
                {
                    // IsPreviewsTerminalInstalled
                    return new TaskStatus(Status.Success);
                }
                else
                {
                    if (now + _callTime >= DateTime.Now)
                    {
                        // EndWorkFlow
                        return new TaskStatus(Status.Error);
                    }
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
