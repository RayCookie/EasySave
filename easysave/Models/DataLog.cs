using System;
using System.Collections.Generic;
using System.Text;



namespace easysave.Model
{
    class DataLogs
    {
        //Declaration of the properties that are used for the program log file
        public string SourceDir { get; set; }
        public string TargetDir { get; set; }
        public string SaveName { get; set; }
        public string BackupDate { get; set; }
        public string TransactionTime { get; set; }
        public long TotalSize { get; set; }


    }
}
