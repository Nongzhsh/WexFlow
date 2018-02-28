using Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Host.Controllers
{
    [Route("api/[controller]/[action]")]
    public class WexFlowController : Controller
    {
        [HttpPost]
        public void Start([FromBody]RequestModel model)
        {
            WexflowWindowsService.WexflowEngine.StartWorkflowModel(model);
        }

        [HttpPost]
        public void Stop([FromBody]RequestModel model)
        {
            WexflowWindowsService.WexflowEngine.StopWorkflowModel(model);
        }
    }
}
