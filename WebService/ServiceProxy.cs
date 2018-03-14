using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebService.CartableService;

namespace WebService
{
    public class ServiceProxy
    {

        public void InsertTask(
            long currentUserId,
            long? flowId,
            long? taskId,
            string taskDecription,
            long employId,
            long requestId,
            long senderID)
        {
            var serviceClient = new CartableServiceClient();

            var taskRequest = new InsertTaskRequest
            {
                employeeID = employId,
                requestID = requestId,
                task = new BaseInputOfCartableGtasGmS9
                {
                    Value = new Cartable
                    {
                        CurrentUserID = currentUserId,
                        TaskID = taskId,
                        FlowID = flowId,
                        SenderID = senderID,
                        Status = 1
                    }
                }
            };
            var result = serviceClient.InsertTask(taskRequest);
        }

        public int CheckConfirm(long requestId)
        {
            CartableServiceClient serviceClient = new CartableServiceClient();
            var result = serviceClient.CheckConfirmRequest(new CheckConfirmRequestRequest
            {
                requestID = new BaseInputOflong { Value = requestId }
            });

            return result.CheckConfirmRequestResult.Value;
        }

        public void ForwardService(
            long id,
            long currentUserId,
            long? flowId,
            long? taskId,
            string taskDecription,
            long requestId
            )
        {
            CartableServiceClient serviceClient = new CartableServiceClient();
            var result = serviceClient.ForwardTask(new ForwardTaskRequest
            {
                task = new BaseInputOfCartableGtasGmS9
                {
                    Value = new Cartable
                    {
                        ID = requestId,
                        CurrentUserID = currentUserId,
                        FlowID = flowId,
                        TaskID = taskId,
                        ActionName = taskDecription
                    }
                },
                requestID = requestId
            });
            // 1,24,25,43,44
        }
    }
}
