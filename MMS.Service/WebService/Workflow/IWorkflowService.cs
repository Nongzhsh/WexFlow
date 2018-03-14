using Contract;
using Helper;
using System.Collections.Generic;
using System.ServiceModel;

namespace Wexflow.Service.Workflow
{

    [ServiceContract]
    public interface IWorkflowService
    {
        [OperationContract]
        bool RunWorkFlow(RequestModel RequestModel);
    }
}
