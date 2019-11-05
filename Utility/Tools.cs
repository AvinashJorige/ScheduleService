using System;
using System.Configuration;
using System.Data;
using System.IO;

namespace Utility
{
    /// <summary>
    /// Generic tool for conversions
    /// </summary>
    public static class Tools
    {
        public delegate T Conversion<T>(T param1);

        /// <summary>
        /// Converting List type to DataTable
        /// </summary>
        /// <param name="data">String value</param>
        /// <returns>Return Datatable from List</returns>
        public static DataTable ConvertListToDataTable(object data)
        {
            try
            {
                if (data != null && !string.IsNullOrEmpty(data.ToString()))
                {
                    Conversion<string> _convertToString = ConvertObjectToString;
                    var ListToString = _convertToString(data.ToString());

                    return Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(ListToString);
                }
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("Tools", "Utility", "ConvertListToDataTable : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            return null;
        }

        /// <summary>
        /// Converting Data type to List
        /// </summary>
        /// <param name="data">String value</param>
        /// <returns>Return List from Datatable</returns>
        public static object ConvertDataTableToList(object data)
        {
            try
            {
                if (data != null && !string.IsNullOrEmpty(data.ToString()))
                {
                    Conversion<string> _convertToString = ConvertObjectToString;
                    var DatatableToString = _convertToString(data.ToString());

                    return Newtonsoft.Json.JsonConvert.DeserializeObject<object>(DatatableToString);
                }
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("Tools", "Utility", "ConvertDataTableToList : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            return null;
        }

        /// <summary>
        /// Converting any data type into string
        /// </summary>
        /// <param name="data">String value</param>
        /// <returns>Return String from any data type</returns>
        public static string ConvertObjectToString(string data)
        {
            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(data);
                }
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("Tools", "Utility", "ConvertDatatableToString : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            return null;
        }

        /// <summary>
        /// Converting string integer into integer
        /// </summary>
        /// <param name="data">String value</param>
        /// <returns>Return integer from string integer</returns>
        public static int ConvertToInt(string data)
        {
            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<int>(data);
                }
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("Tools", "Utility", "ConvertToInt : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            return 0;
        }

        /// <summary>
        /// Converts the all the data type into any data type
        /// Converts the string boolean into boolean
        /// Converts the string integer into integer
        /// </summary>
        /// <typeparam name="T">Any Data type</typeparam>
        /// <param name="value">String value</param>
        /// <returns>Any data type</returns>
        public static T ParseOrDefault<T>(this string value)
        {
            try
            {
                return ReferenceEquals(value, null)
                         ? default(T) : (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("Tools", "Utility", "ParseOrDefault : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// Get the App setting value and converts into any data type
        /// </summary>
        /// <typeparam name="T">Any Data type</typeparam>
        /// <param name="settingName">String value</param>
        /// <returns>Return Appsetting value</returns>
        public static T ConfigSetting<T>(string settingName)
        {
            object value = ConfigurationManager.AppSettings[settingName];
            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// Converts the datetime tick into days, hours, mins
        /// </summary>
        /// <param name="ticks">Datetime Ticks</param>
        /// <returns>Days, Hours, Minutes</returns>
        public static string TicksToTime(long ticks)
        {
            if (ticks == 0)
            {
                return null;
            }

            var time = ticks; // Time value in ticks
            var days = Math.Floor(double.Parse((time / (24 * 60 * 60 * long.Parse("10000000"))).ToString()));
            var hours = Math.Round(double.Parse(((time / (60 * 60 * long.Parse("10000000"))) % 24).ToString()));
            var mins = Math.Round(double.Parse((time / (60 * long.Parse("10000000")) % 60).ToString()));

            return ("days: " + days + ", hours: " + hours + ", mins: " + mins);
        }

        public static string ConvertDataTableToXMLString(DataTable _dtTbl)
        {
            if(_dtTbl != null && _dtTbl.Rows.Count > 0)
            {
                StringWriter sw_writer = new StringWriter();
                _dtTbl.WriteXml(sw_writer);
                return sw_writer.ToString();
            }
            return null;
        }

        public static bool IsNullDataSet(DataSet _dsSet)
        {
            bool bflag = false;
            if(_dsSet != null)
            {
                for (int i = 0; i < _dsSet.Tables.Count ; i++)
                {
                    if(_dsSet.Tables[i] != null && _dsSet.Tables[i].Rows.Count > 0)
                    {
                        bflag = true;
                    }
                }
            }
            return bflag;
        }
    }
}
