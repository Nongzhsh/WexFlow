using Contract;
using System;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.NeedCheckByBank
{
    public class NeedCheckByBank : Task
    {
        static TimeSpan _interval;

        public NeedCheckByBank(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("interval")))
                _interval = TimeSpan.Parse(GetSetting("interval"));
        }

        public override TaskStatus Run(RequestModel model = null)
        {
            var serviceResult = true;

            while (true)
            {
                if (serviceResult)
                {
                    // IsPreviewsTerminalInstalled
                    return new TaskStatus(Status.Success);
                }
                else
                {
                    return new TaskStatus(Status.Error);
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
