using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.End
{
    public class End : Task
    {
        public End(XElement xe, Workflow wf) : base(xe, wf)
        {
        }

        public override TaskStatus Run(RequestModel model = null)
        {
            return new TaskStatus(Status.Success);
        }
    }
}
