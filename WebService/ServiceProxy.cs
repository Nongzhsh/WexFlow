using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebService
{
    public class ServiceProxy
    {

        public void InsertTask()
        {
            CartableService.CartableServiceClient serviceClient = new CartableService.CartableServiceClient();
            serviceClient.InsertTask(new CartableService.InsertTaskRequest
            {
                task = new CartableService.BaseInputOfCartableGtasGmS9
                {
                    Value = new CartableService.Cartable
                    {
                        ID = 1,
                        CurrentUserID = 1,
                        TaskID = 1,
                        FlowID = 2
                    }
                }
            });
        }

        public void ForwardService(long userId, long? flowId, long? taskId)
        {
            CartableService.CartableServiceClient serviceClient = new CartableService.CartableServiceClient();
            serviceClient.ForwardTask(new CartableService.ForwardTaskRequest
            {
                task = new CartableService.BaseInputOfCartableGtasGmS9
                {
                    Value = new CartableService.Cartable
                    {
                        ID = 2,
                        CurrentUserID = userId,
                        FlowID = flowId,
                        TaskID = taskId
                    }
                }
            });
            // 1,24,25,43,44
        }
    }
}
