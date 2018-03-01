using Contract;
using DataModel;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.AddEmploy
{
    public class AddEmploy : Task
    {
        public static string _adminId;
        public AddEmploy(XElement xe, Workflow wf) : base(xe, wf)
        {
            _adminId = this.GetSetting("UserId");
        }

        public override TaskStatus Run(RequestModel model)
        {
            if (model == null)
            {
                model = new RequestModel { Name = "Null Input Value" };
            }
            var modelProvider = new ModelProvider();

            var addEmploy = modelProvider.AddEmployee(
                new Emplo
                {
                    Name = model.Name,
                    AdminId = int.Parse(_adminId),
                    Status = "waiting"
                });
            if (addEmploy.Success)
            {
                model.EmpId = addEmploy.Id;
                return new TaskStatus(Status.Success);
            }
            return new TaskStatus(Status.Error);
        }
    }
}
