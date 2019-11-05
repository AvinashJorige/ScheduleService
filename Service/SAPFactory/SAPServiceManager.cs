using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using Utility;
using Newtonsoft;

namespace Service.SAPFactory
{
    public class SAPServiceManager : SAPServiceConfigManager
    {
        public override ISAPServiceManager GetSAPService(string SAPType)
        {
            SAPType = SAPType.ToLower();
            switch (SAPType)
            {
                case "datatable":
                    return new SAPDatatableConnection();
                case "dataset":
                    return new SAPDatasetConnection();

                default:
                    throw new ApplicationException(string.Format("SAP Connection '{0}' cannot be created", SAPType));
            }
        }
    }
}
