//using Contract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Xml;

//namespace WebService
//{
//    public class GetTaskInfo
//    {
//        public TaskModel GetTaskInfo(string taskName)
//        {
//            XmlDocument doc = new XmlDocument();
//            doc.Load("C:\\Wexflow\\Workflows\\Cancelation.xml");

//            var node = doc.DocumentElement.ChildNodes[1].ChildNodes[1].ChildNodes.Where;


//            var id = node.Attributes[0].Value;
//            var desc = node.Attributes[2].Value;
//            string text = node.InnerText; //or loop through its children as well

//        }
//    }
//}
