using Contract;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;
using System.Data.SqlClient;
using DataModel;

namespace Wexflow.Tasks.MyTask
{

    public class MyTask : Task
    {

        public MyTask(XElement xe, Workflow wf) : base(xe, wf)
        {
            string settingValue = this.GetSetting("UserId");
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
