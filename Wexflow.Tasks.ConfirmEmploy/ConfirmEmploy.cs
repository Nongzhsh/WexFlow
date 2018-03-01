using Contract;
using DataModel;
using System;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.ConfirmEmploy
{
    public class ConfirmEmploy : Task
    {
        private TimeSpan Duration { get; set; }
        public ConfirmEmploy(XElement xe, Workflow wf) : base(xe, wf)
        {
            Duration = TimeSpan.Parse(GetSetting("duration"));
        }

        public override TaskStatus Run(RequestModel model)
        {
            var modelProvider = new ModelProvider();
            while (true)
            {
                Thread.Sleep(Duration);
                var status = modelProvider.GetEmployStatus(model.EmpId);

                if (status == "accept")
                    return new TaskStatus(Status.Success);
                if (status == "reject")
                    return new TaskStatus(Status.Error);
            }
        }
    }
}
