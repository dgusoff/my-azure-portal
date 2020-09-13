using System;
using System.Collections.Generic;
using System.Text;

namespace my_portal.models
{
    public interface IArmData
    {
        public string GetSubscriptions(string accessToken);
    }
}
