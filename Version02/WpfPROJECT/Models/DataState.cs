using System;
using System.Collections.Generic;
using System.Text;

namespace WpfPROJECT.Models
{
    class DataState
    {
        // Declaration of properties that are used for saving information for the report file in JSON
        public string SaveName { get; set; }
        public string BackupDate { get; set; }
        public bool SaveState { get; set; }
        public string SourceFile { get; set; }
        public string TargetFile { get; set; }
        public float TotalFile { get; set; }
        public long TotalSize { get; set; }
        public float Progress { get; set; }
        public long FileRest { get; set; }
        public long TotalSizeRest { get; set; }

        public DataState(string saveName)
        {
            SaveName = saveName;
        }
    }
}
