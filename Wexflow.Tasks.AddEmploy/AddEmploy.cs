using Contract;
using DataModel;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.AddEmploy
{
    public class AddEmploy: Task
    {
        public AddEmploy(XElement xe, Workflow wf) : base(xe, wf)
        {
            //string settingValue = this.GetSetting("UserId");
        }

        public override TaskStatus Run(RequestModel model)
        {
            if (model == null)
            {
                model = new RequestModel { Name = "Null Input Value" };
            }
            var modelProvider = new ModelProvider();

            if (modelProvider.AddEmployee(new Emplo { Name = model.Name }))
            {
                return new TaskStatus(Status.Success);
            }
            return new TaskStatus(Status.Error);
        }
    }
}
