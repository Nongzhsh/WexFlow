using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.Complete
{
    public class Complete : Task
    {
        public Complete(XElement xe, Workflow wf) : base(xe, wf)
        {
        }

        public override TaskStatus Run(RequestModel model = null)
        {
            return new TaskStatus(Status.Success);
        }
    }
}
