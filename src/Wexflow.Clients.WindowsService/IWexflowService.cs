using System.IO;
using System.ServiceModel;
using Wexflow.Core.Service.Contracts;
using static Wexflow.Clients.WindowsService.WexflowService;

namespace Wexflow.Clients.WindowsService
{
    [ServiceContract(Namespace = "http://wexflow.com/")]
    public interface IWexflowService
    {
        [OperationContract]
        WorkflowInfo[] GetWorkflows();

        [OperationContract]
        void StartWorkflow(string model, RequestModel aaa);

        [OperationContract]
        void StopWorkflow(string id);

        [OperationContract]
        void SuspendWorkflow(string id);

        [OperationContract]
        void ResumeWorkflow(string id);

        [OperationContract]
        WorkflowInfo GetWorkflow(string id);

        [OperationContract]
        TaskInfo[] GetTasks(string id);

        [OperationContract]
        string GetWorkflowXml(string id);

        [OperationContract]
        bool SaveWorkflow(Stream streamdata);

        [OperationContract]
        string[] GetTaskNames();

        [OperationContract]
        string GetWorkflowsFolder();

        [OperationContract]
        bool IsWorkflowIdValid(string id);

        [OperationContract]
        bool DeleteWorkflow(string id);

        [OperationContract]
        string[] GetSettings(string taskName);

        [OperationContract]
        Node[] GetExecutionGraph(string id);

        [OperationContract]
        string GetTaskXml(Stream streamdata);
    }
}
