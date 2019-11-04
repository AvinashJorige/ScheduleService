using System.Collections.Generic;
using System.Data;

namespace Service.SAPFactory
{
    public interface ISAPServiceManager
    {
        DataTable ConnectSAPService(List<string> input);
    }
}
