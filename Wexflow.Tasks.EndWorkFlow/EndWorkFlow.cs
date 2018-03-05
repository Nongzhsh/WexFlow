using Cancelation.Core;
using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.EndWorkFlow
{
    public class EndWorkFlow : Task
    {
        static TimeSpan _interval;
        public EndWorkFlow(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("interval")))
                _interval = TimeSpan.Parse(GetSetting("interval"));

        }

        public override TaskStatus Run(RequestModel model = null)
        {
            return new TaskStatus(Status.Success);
        }
    }
}
