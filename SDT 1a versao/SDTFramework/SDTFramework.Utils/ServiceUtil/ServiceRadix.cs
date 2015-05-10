using System.Collections.Generic;
using System.ServiceProcess;

namespace SDTFramework.Utils.ServiceUtil
{
    public class ServiceRadix : ServiceBase
    {
        protected readonly List<ServiceObject> Processes = new List<ServiceObject>();

        protected override void OnStart(string[] args)
        {
            foreach (ServiceObject serviceObject in Processes)
            {
                serviceObject.OnStart(args);
            }
        }

        protected override void OnStop()
        {
            foreach (ServiceObject serviceObject in Processes)
            {
                serviceObject.OnStop();
            }
        }

        protected override void OnContinue()
        {
            foreach (ServiceObject serviceObject in Processes)
            {
                serviceObject.OnContinue();
            }
        }

        protected override void OnPause()
        {
            foreach (ServiceObject serviceObject in Processes)
            {
                serviceObject.OnPause();
            }
        }

        protected override void OnShutdown()
        {
            foreach (ServiceObject serviceObject in Processes)
            {
                serviceObject.OnShutdown();
            }
        }
    }
}
