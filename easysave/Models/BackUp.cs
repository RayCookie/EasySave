using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easysave.Models
{
    class BackUp
    {
        // Declaration of properties that are used for saving backup information for the backup job file
        public string SourceDir { get; set; }
        public string TargetDir { get; set; }
        public string SaveName { get; set; }
        public int Type { get; set; }
        public string MirrorDir { get; set; }

        public BackUp(string saveName, string sourceDir, string targetDir, int type, string mirrorDir)
        {
            SaveName = saveName;
            SourceDir = sourceDir;
            TargetDir = targetDir;
            Type = type;
            MirrorDir = mirrorDir;
        }
}
