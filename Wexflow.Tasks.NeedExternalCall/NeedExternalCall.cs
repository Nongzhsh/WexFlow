using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.NeedExternalCall
{
    public class NeedExternalCall : Task
    {
        static TimeSpan _interval;
        static long _userId;
        public NeedExternalCall(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("interval")))
                _interval = TimeSpan.Parse(GetSetting("interval"));

            if (!string.IsNullOrWhiteSpace(GetSetting("userId")))
                _userId = long.Parse(GetSetting("userId"));
        }

        public override TaskStatus Run(RequestModel model = null)
        {
            var serviceResult = false;

            while (true)
            {
                if (serviceResult)
                {
                    // افزودن به کارتابل تماس خروجی
                    // بررسی کارتابل تماس خروجی
                    return new TaskStatus(Status.Success, true);
                }
                else
                {

                    return new TaskStatus(Status.Error, false);
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
