using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.IsPreviewsTerminalInstalled
{
    public class IsPreviewsTerminalInstalled : Task
    {
        static TimeSpan _interval;
        static TimeSpan _callTime;
        public IsPreviewsTerminalInstalled(XElement xe, Workflow wf) : base(xe, wf)
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
                    // تایید ابطال
                    // IsNewMarketing
                    return new TaskStatus(Status.Success);
                }
                else
                {
                    if (now + _callTime >= DateTime.Now)
                    {
                        // IsCurrentTerminalInstalled
                        return new TaskStatus(Status.Error);
                    }
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
