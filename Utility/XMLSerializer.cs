using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Utility
{
    public class XMLSerializer
    {
        public enum OutputType
        {
            DataTable,
            String,
            List,
            DataSet,
            ObjectList
        }

        public enum InputType
        {
            DataTable,
            String,
            List,
            DataSet,
            ObjectList
        }

        public static XmlDocument Serialize(object Obj, InputType inputType)
        {
            Type ObjType = null;

            switch (inputType)
            {
                case InputType.DataTable: ObjType = typeof(DataTable); break;
                case InputType.List: ObjType = typeof(List<string>); break;
                case InputType.String: ObjType = typeof(string); break;
                case InputType.DataSet: ObjType = typeof(DataSet); break;
                case InputType.ObjectList: ObjType = typeof(List<object>); break;
            }

            XmlSerializer serializer = new XmlSerializer(ObjType);
            XmlDocument xmlDocument = new XmlDocument();

            using (XmlWriter xmlWriter = xmlDocument.CreateNavigator().AppendChild())
            {
                serializer.Serialize(xmlWriter, Obj);
            }
            return xmlDocument;
        }

        public static object Deserialize(string Xml, OutputType outputType)
        {
            Type ObjType = null;

            switch (outputType)
            {
                case OutputType.DataTable: ObjType = typeof(DataTable); break;
                case OutputType.List: ObjType = typeof(List<string>); break;
                case OutputType.String: ObjType = typeof(string); break;
                case OutputType.DataSet: ObjType = typeof(DataSet); break;
                case OutputType.ObjectList: ObjType = typeof(List<object>); break;
            }

            XmlSerializer ser;
            ser = new XmlSerializer(ObjType);
            StringReader stringReader;
            stringReader = new StringReader(Xml);
            XmlTextReader xmlReader;
            xmlReader = new XmlTextReader(stringReader);
            object obj;
            obj = ser.Deserialize(xmlReader);
            xmlReader.Close();
            stringReader.Close();
            return obj;
        }
    }
}
