using Contract;
using Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace TestHost.Controllers
{
    [Route("api/[controller]/[action]")]
    public class WexFlowController : ApiController
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
