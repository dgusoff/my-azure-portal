using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_azure_portal.web
{
    public class Constants
    {
        public static string GET_CONTAINER_INSTANCE_URL = "https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}?api-version=2019-12-01";
    }
}
