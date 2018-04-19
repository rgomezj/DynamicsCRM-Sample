using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsCRMSample
{
    public class ContactCreatedHandler : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            //Extract the tracing service for use in debugging sandboxed plug-ins.
            ITracingService tracingService =
                (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context from the service provider.
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Obtain the target entity from the input parameters.
            Entity entity = (Entity)context.InputParameters["Target"];
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<String, Object> attribute in entity.Attributes)
            {
                builder.AppendLine(attribute.Key + ": " + attribute.Value);
            }

            tracingService.Trace("Entity attributes: {0}", builder.ToString());
            // Comment test to trigger a webhook
        }
    }
}
