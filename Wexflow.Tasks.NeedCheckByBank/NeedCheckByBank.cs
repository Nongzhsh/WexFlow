using Contract;
using System;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using WebService;
using Wexflow.Core;

namespace Wexflow.Tasks.NeedCheckByBank
{
    public class NeedCheckByBank : Task
    {
        static TimeSpan _interval;
        static long _userId;

        public NeedCheckByBank(XElement xe, Workflow wf) : base(xe, wf)
        {
            if (!string.IsNullOrWhiteSpace(GetSetting("interval")))
                _interval = TimeSpan.Parse(GetSetting("interval"));

            if (!string.IsNullOrWhiteSpace(GetSetting("userId")))
                _userId = long.Parse(GetSetting("userId"));
        }

        public override TaskStatus Run(RequestModel model = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Wexflow\\Workflows\\Cancelation.xml");

            foreach (XmlNode node in doc.DocumentElement.ChildNodes[1].ChildNodes)
            {
                var id = node.Attributes[0].Value;
                var desc = node.Attributes[2].Value;
                string text = node.InnerText; //or loop through its children as well
            }

            new ServiceProxy().InsertTask();
            var serviceResult = false;

            while (true)
            {
                if (serviceResult)
                {
                    // IsPreviewsTerminalInstalled
                    return new TaskStatus(Status.Success, true);
                }
                else
                {
                    return new TaskStatus(Status.Error, false);
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
