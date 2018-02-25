using Contract;
using Microsoft.AspNetCore.Mvc;
using Wexflow.Tasks.MyTask;

namespace Host.Controllers
{
    [Route("api/[controller]/[action]")]
    public class WexFlowController : Controller
    {
        [HttpPost]
        public void Start ([FromBody]RequestModel model)
        {
            //new MyTask().Run();
            WexflowWindowsService.WexflowEngine.StartWorkflowModel(model);
        }
    }
}
