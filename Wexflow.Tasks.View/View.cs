using Contract;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.View
{
    public class View : Task
    {
        public View(XElement xe, Workflow wf) : base(xe, wf)
        {
            //string settingValue = this.GetSetting("UserId");
        }

        public override TaskStatus Run(RequestModel model)
        {
            return new TaskStatus(Status.Success);
        }
    }
}
