using System;
using System.Collections.Generic;
using System.Text;

namespace Contract
{
    public class RequestModel
    {
        public int WorkflowId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int EmpId { get; set; }
    }
}
