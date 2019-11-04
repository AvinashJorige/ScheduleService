using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SAPFactory
{
    public abstract class SAPServiceConfigManager
    {
        public abstract ISAPServiceManager GetSAPService(string SAPType);
    }
}
