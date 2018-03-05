using Cancelation.Core;
using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.CheckConditions
{
    public class CheckConditions : Task
    {
        static string _userId;
        static TimeSpan _interval;

        public CheckConditions(XElement xe, Workflow wf) : base(xe, wf)
        {
            _userId = GetSetting("userId");

            if (!string.IsNullOrWhiteSpace(GetSetting("interval")))
                _interval = TimeSpan.Parse(GetSetting("interval"));

        }

        public override TaskStatus Run(RequestModel model = null)
        {
            TimeHolder.SetStartTime();
            // TODO EXCEPTION HANDLING.
            // TODO IMPLEMENT WEB SERVICES TO GET CONDITION RESULT.
            model.UserId = int.Parse(_userId);
            var serviceResult = true;

            while (true)
            {
                if (serviceResult)
                {
                    // TODO SET USERID
                    return new TaskStatus(Status.Success);
                }
                else
                {
                    // TODO SET USERID
                    return new TaskStatus(Status.Error);
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
