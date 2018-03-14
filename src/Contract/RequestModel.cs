using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Contract
{
    [DataContract]
    public class RequestModel
    {
        //[DataMember]
        //public int WorkflowId { get; set; }
        //[DataMember]
        //public int UserId { get; set; }
        //[DataMember]
        //public string Name { get; set; }
        //[DataMember]
        //public int EmpId { get; set; }
        //[DataMember]
        //public long ID { get; set; }
        //[DataMember]
        //public long CurrentUserID { get; set; }
        //[DataMember]
        //public long? TaskID { get; set; }
        //[DataMember]
        //public long SenderID { get; set; }
        //[DataMember]
        //public long EmployeeID { get; set; }
        public int Id { get; set; }
        public string TaskModel { get; set; }
    }

    public class InnerRequestModel
    {
        public long EmployeeID { get; set; }
        public long RequestID { get; set; }
    }
}
