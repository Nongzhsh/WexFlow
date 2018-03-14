using Contract;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Xml.Linq;
using WebService;
using Wexflow.Core;

namespace Wexflow.Tasks.IsCurrentTerminalInstalled
{
    public class IsCurrentTerminalInstalled : Task
    {
        static TimeSpan _interval;
        static long _userId;
        public IsCurrentTerminalInstalled(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("interval")))
                _interval = TimeSpan.Parse(GetSetting("interval"));

            if (!string.IsNullOrWhiteSpace(GetSetting("userId")))
                _userId = long.Parse(GetSetting("userId"));
        }

        public override TaskStatus Run(RequestModel model = null)
        {
            var taskID = GetTaskInfo.GetTaskId(GetType().Name);
            var taskDescription = GetTaskInfo.GetTaskDescriotion(GetType().Name);
            var innerRequestModel = JsonConvert.DeserializeObject<InnerRequestModel>(model.TaskModel);
            var currentUserID = _userId;
            new ServiceProxy().ForwardService(
                innerRequestModel.RequestID,
                currentUserID,
                model.Id,
                taskID,
                taskDescription,
                innerRequestModel.RequestID);
            while (true)
            {
                var serviceResult = new ServiceProxy().CheckConfirm(innerRequestModel.RequestID);
                if (serviceResult == 1)
                {
                    return new TaskStatus(Status.Success, true);
                }
                else if (serviceResult == 0)
                {
                    return new TaskStatus(Status.Error, false);
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
