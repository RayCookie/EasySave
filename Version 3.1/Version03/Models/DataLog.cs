using System;
using System.Xml;
using System.Xml.Serialization;

namespace Version03.Models
{
    [XmlRoot("DataLog"), XmlType("DataLog")]
  public  class DataLogs
    {
        public static string filepath = @"..\..\..\Config\Log.xml";

        //Declaration of the properties that are used for the program log file
        [XmlElement(ElementName = "SourceDir")]
        public string SourceDir { get; set; }
        [XmlElement(ElementName = "TargetDir")]
        public string TargetDir { get; set; }
        [XmlElement(ElementName = "MirrorDir")]
        public string MirrorDir { get; set; }
        [XmlElement(ElementName = "SaveName")]
        public string SaveName { get; set; }
        [XmlElement(ElementName = "BackupDate")]
        public string BackupDate { get; set; }
        [XmlElement(ElementName = "TransactionTime")]
        public string TransactionTime { get; set; }
        [XmlElement(ElementName = "TotalSize")]
        public long TotalSize { get; set; }


    }
}
