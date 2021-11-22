using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easysave.Models
{
    class DataState
    {
        public string Name { get; set; }
        public DateTime statedate { get; set; }
        public Boolean SaveState { get; set; }
        public float TotalNumberFileToCopy { get; set; }
        public float TotalFileSize { get; set; }
        public string PathSourceFile { get; set; }
        public string PathFileDestination { get; set; }
        public float NumberFileRemaining { get; set; }
        public float SizeRemainingFile { get; set; }
        public float Progression { get; set; }
        public DataState(string Name)
        {
            Name = "";
            statedate="";
            SaveState=0;
            TotalNumberFileToCopy=0;
            TotalFileSize=0;
            PathSourceFile="";
            NumberFileRemaining=0;
            SizeRemainingFile=0;
            Progression=0;







        }
    }
}
