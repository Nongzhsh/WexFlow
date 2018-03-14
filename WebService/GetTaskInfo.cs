using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebService
{
    public static class GetTaskInfo
    {
        public static long GetTaskId(string taskName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Wexflow\\Workflows\\Cancelation.xml");

            foreach (XmlNode node in doc.DocumentElement.ChildNodes[1].ChildNodes)
            {
                if (node.Attributes[1].Value == taskName)
                {
                    return long.Parse(node.Attributes[0].Value);
                }
            }
            return 0;
        }

        public static string GetTaskDescriotion(string taskName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Wexflow\\Workflows\\Cancelation.xml");

            foreach (XmlNode node in doc.DocumentElement.ChildNodes[1].ChildNodes)
            {
                if (node.Attributes[1].Value == taskName)
                {
                    return node.Attributes[2].Value;
                }
            }
            return null;
        }
    }
}
