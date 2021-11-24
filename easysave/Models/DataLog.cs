using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace easysave.Models
{
    class DataLog
    {
        public string SourceDir { get; set; }
        public string TargetDir { get; set; }
        public string SaveName { get; set; }
        public string BackupDate { get; set; }
        public string FileTransferTime { get; set; }
        public long TotalSize { get; set; }

    }
}
