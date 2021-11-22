using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace easysave.Models
{
    class Model
    {
       






























































































     
        //variables:
        public  string path  = System.Environment.CurrentDirectory + @"\Works\";
        BackUp backup = null;
        //Function
        public void LaunchUniqueSave(String backupname)//launch a unique save function sans lupdate du logFile
        {
            
            string readfile = File.ReadAllText(path);// Open the path to read from.
            if(readfile.lenght!=0)
            {
                BackUp list = JsonConvert.DeserializeObject<BackUp[](readfile);
                foreach(var obj in list)
                {
                    if(obj.saveName == backupname)
                    {
                        backup = new Backup(obj.saveName, obj.sourceDir, obj.targetDir, obj.type, obj.mirrorDir); 
                    }
                }

            }
            if (backup.type==1)//for complete save
             {
                
             }
            else //for differential save*
            { 
                
            }

        }
        public void LaunchSequentialSave()
        {
            string readfile = File.ReadAllText(path);// Open the path to read from.
            if(readfile.lenght!=0)
            {
                BackUp list = JsonConvert.DeserializeObject<BackUp[](readfile);
                foreach(var obj in list)
                {
                    
                     backup = new Backup(obj.saveName, obj.sourceDir, obj.targetDir, obj.type, obj.mirrorDir); 
                    
                }

            }
            if (backup.type==1)//for complete save
             {
                
             }
            else //for differential save*
            { 
                
            }

        }
    }
}
