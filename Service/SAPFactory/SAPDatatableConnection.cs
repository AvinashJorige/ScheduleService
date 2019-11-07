using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using Utility;

namespace Service.SAPFactory
{
    public class SAPDatatableConnection : ISAPServiceManager
    {
        /// <summary>
        /// Connect with the SAP Service. Used for CRUD operation with SAP Service if using with the datatable
        /// </summary>
        /// <param name="input">Input List of string paramaters</param>
        /// <param name="SAPService">Sap service RFC name</param>
        /// <returns>Datatable</returns>
        public object ConnectSAPService(List<string> input, string SAPService)
        {
            long TimeTookticks          = DateTime.Now.Ticks;
            XmlNode xmlExceptionLocStat = null;
            SAPService _SAPCon          = null;
            XmlElement xDocTableLocStat = null;
            XmlDocument xDocLocStat     = null;
            DataTable _datatable        = new DataTable();

            try
            {
                Log4net.LogWriter("SAPService", "Service", "ConnectSAPService || Started : " + Tools.TicksToTime(DateTime.Now.Ticks), Entities.LogType.LogMode.Debug);

                _SAPCon          = new SAPService(AppSettingConfig.GetConfigAppSetting("SAPWebServiceURL"));
                xDocLocStat      = XMLSerializer.Serialize(input, XMLSerializer.InputType.List);
                switch (SAPService)
                {
                    case "GetTableData":
                        xDocTableLocStat = (XmlElement)_SAPCon.GetTableData(xDocLocStat, out xmlExceptionLocStat);
                        break;
                    case "R3EmpCreation":
                        xDocTableLocStat = (XmlElement)_SAPCon.R3EmpCreation(xDocLocStat, out xmlExceptionLocStat);
                        break;
                }

                xDocTableLocStat = (XmlElement)_SAPCon.GetTableData(xDocLocStat, out xmlExceptionLocStat);

                List<string> SAPErrorLocStat = (List<string>)XMLSerializer.Deserialize(xmlExceptionLocStat.OuterXml, XMLSerializer.OutputType.List);

                if (SAPErrorLocStat != null && SAPErrorLocStat.Count > 0 && SAPErrorLocStat[0] != null && SAPErrorLocStat[0].ToString() == "1000")
                {
                    _datatable = (DataTable)XMLSerializer.Deserialize(xDocTableLocStat.OuterXml, XMLSerializer.OutputType.DataTable);
                }

                Log4net.LogWriter("SAPService", "Service", "ConnectSAPService || Resultset Datatable : " + Newtonsoft.Json.JsonConvert.SerializeObject(_datatable), Entities.LogType.LogMode.Debug);
                Log4net.LogWriter("SAPService", "Service", "ConnectSAPService || Resultset Datatable End: --------------------------------" + Environment.NewLine +""+ Environment.NewLine, Entities.LogType.LogMode.Debug);
                Log4net.LogWriter("SAPService", "Service", "ConnectSAPService || Service Ended : " + Tools.TicksToTime(TimeTookticks), Entities.LogType.LogMode.Debug);
                Log4net.LogWriter("SAPService", "Service", "ConnectSAPService || Service Ended: --------------------------------" + Environment.NewLine + "" + Environment.NewLine, Entities.LogType.LogMode.Debug);

                return _datatable;
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("SAPService", "Service", "ConnectSAPService || Error : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            finally
            {
                _datatable          = null;
                _SAPCon             = null;
                xDocLocStat         = null;
                xDocTableLocStat    = null;
                xmlExceptionLocStat = null;
            }
            return null;
        }
    }
}
