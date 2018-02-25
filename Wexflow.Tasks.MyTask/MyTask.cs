using System;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using Wexflow.Core;

namespace Wexflow.Tasks.MyTask
{
    public class MyTask: Task
    {
        public MyTask(XElement xe, Workflow wf) : base(xe, wf)
        {
            // Task settings goes here
        }

        public override TaskStatus Run()
        {
            try
            {
                string fileName = @"C:\MyLog.txt";

                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }
                File.AppendAllText(fileName, DateTime.Now.ToString() + Environment.NewLine);

                return new TaskStatus(Status.Success);
            }
            catch (ThreadAbortException)
            {
                throw;
            }
        }
    }
}
