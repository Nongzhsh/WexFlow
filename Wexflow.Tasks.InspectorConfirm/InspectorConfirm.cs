using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using WebService;
using Wexflow.Core;

namespace Wexflow.Tasks.InspectorConfirm
{
    public class InspectorConfirm : Task
    {
        static TimeSpan _interval;
        static long _userId;
        public InspectorConfirm(XElement xe, Workflow wf) : base(xe, wf)
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
            var serviceResult = true;
            new ServiceProxy().ForwardService(_userId, 2, 3);
            while (true)
            {
                if (serviceResult)
                {
                    // TODO SEND USERID
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
