using System.Collections.Generic;
using System.Data;

namespace Service.SAPFactory
{
    public interface ISAPServiceManager
    {
        object ConnectSAPService(List<string> input, string SAPService);        
    }
}
