using Contract;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.MyTask
{

    public class MyTask: Task
    {

        public MyTask(XElement xe, Workflow wf) : base(xe, wf)
        {
            string settingValue = this.GetSetting("selectEntities");
        }

        public override TaskStatus Run(RequestModel model)
        {
            try
            {
                string fileName = @"C:\MyLog.txt";
                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }
                var text = model != null ? model.Name : "arash";
                File.AppendAllText(fileName, text + Environment.NewLine);
                return new TaskStatus(Status.Success);
            }
            catch (ThreadAbortException)
            {
                throw;
            }
        }
    }
}
