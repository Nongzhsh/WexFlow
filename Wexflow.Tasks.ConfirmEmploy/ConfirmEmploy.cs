using Contract;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.ConfirmEmploy
{
    public class ConfirmEmploy : Task
    {
        public ConfirmEmploy(XElement xe, Workflow wf) : base(xe, wf)
        {
            //string settingValue = this.GetSetting("UserId");
        }

        public override TaskStatus Run(RequestModel model)
        {

            return new TaskStatus(Status.Success);
        }

    }
}
