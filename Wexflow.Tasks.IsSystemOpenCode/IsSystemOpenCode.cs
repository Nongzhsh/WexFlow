using Contract;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Xml.Linq;
using WebService;
using Wexflow.Core;

namespace Wexflow.Tasks.IsSystemOpenCode
{
    public class IsSystemOpenCode : Task
    {
        static TimeSpan _interval;
        static TimeSpan _callTime;
        static long _userId;
        public IsSystemOpenCode(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("callTime")))
                _callTime = TimeSpan.Parse(GetSetting("callTime"));

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
            var now = DateTime.Now;
            while (true)
            {
                var serviceResult = new ServiceProxy().CheckConfirm(innerRequestModel.RequestID);
                if (serviceResult == 1)
                {
                    // IsPreviewsTerminalInstalled
                    return new TaskStatus(Status.Success, true);
                }
                else if (serviceResult == 0)
                {
                    if (now + _callTime >= DateTime.Now)
                    {
                        // EndWorkFlow
                        return new TaskStatus(Status.Error, false);
                    }
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
