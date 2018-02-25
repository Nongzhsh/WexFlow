using Contract;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]/[action]")]
    public class WexFlowController : Controller
    {
        [HttpPost]
        public void Start ([FromBody]RequestModel model)
        {
            WexflowWindowsService.WexflowEngine.StartWorkflowModel(model);
        }
    }
}
