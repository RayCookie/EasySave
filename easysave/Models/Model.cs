using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

using System.Diagnostics;
namespace easysave.Models
{
    class Model
    {
        //variables
        public DataState DataState { get; set; }
        public string userMenuInput { get; set; }
        private string serializeObj;
         public string NameStateFile { get; set; }
        public TimeSpan TimeTransfert { get; set; }

        public string backupListFile = System.Environment.CurrentDirectory + @"\\";
        public string stateFile = System.Environment.CurrentDirectory + @"\\";
        public string SourceDir { get; set; }
        public string TargetDir { get; set; }
        public long TotalSize { get; set; }
        public Model()
        {
            userMenuInput =  " ";

            if (!Directory.Exists(backupListFile)) //Check if the folder is created
            {
                DirectoryInfo di = Directory.CreateDirectory(backupListFile); //Function that creates the folder
            }
            backupListFile += @"backupList.json"; //Create a JSON file

            if (!Directory.Exists(stateFile))//Check if the folder is created
            {
                DirectoryInfo di = Directory.CreateDirectory(stateFile); //Function that creates the folder
            }
            stateFile += @"state.json"; //Create a JSON file


        }

        public void AddStateFile() //Function that allows you to add a backup job to the report file.
        {
            List<DataState> stateList = new List<DataState>();
            this.serializeObj = null;

            if (!File.Exists(stateFile)) //Checking if the file exists
            {
                File.Create(stateFile).Close();
            }

            string jsonString = File.ReadAllText(stateFile); //Reading the json file

            if (jsonString.Length != 0)
            {
                DataState[] list = JsonConvert.DeserializeObject<DataState[]>(jsonString); //Derialization of the json file
                foreach (var obj in list) //Loop to add the information in the json
                {
                    stateList.Add(obj);//il ajoute les element recuperer dans le fichier statelist
                }
            }
            this.DataState.SaveState = false;
            stateList.Add(this.DataState); //met les parametres de datastate dans une liste

            this.serializeObj = JsonConvert.SerializeObject(stateList.ToArray(), Formatting.Indented) + Environment.NewLine; //Serialization for writing to json file
            File.WriteAllText(stateFile, this.serializeObj);// Writing to the json file


        }

         private void UpdateStatefile()//Function that updates the status file.
        {
            List<DataState> stateList = new List<DataState>();
            this.serializeObj = null;
            if (!File.Exists(stateFile)) //Checking if the file exists
            {
                File.Create(stateFile).Close();
            }

            string jsonString = File.ReadAllText(stateFile);  //Reading the json file

            if (jsonString.Length != 0) //Checking the contents of the json file is empty or not
            {
                DataState[] list = JsonConvert.DeserializeObject<DataState[]>(jsonString); //Derialization of the json file

                foreach (var obj in list) // Loop to allow filling of the JSON file
                {
                    if(obj.Name == this.NameStateFile) //Verification so that the name in the json is the same as that of the backup
                    {
                        obj.PathSourceFile = this.DataState.PathSourceFile;
                        obj.PathFileDestination = this.DataState.PathFileDestination;
                        obj.TotalNumberFileToCopy = this.DataState.TotalNumberFileToCopy;
                        obj.TotalFileSize = this.DataState.TotalFileSize;
                        obj.NumberFileRemaining = this.DataState.NumberFileRemaining;
                        obj.SizeRemainingFile = this.DataState.SizeRemainingFile;
                        obj.Progression = this.DataState.Progression;
                        obj.statedate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        obj.SaveState = this.DataState.SaveState;
                    }

                    stateList.Add(obj); //Allows you to prepare the objects for the json filling

                }

                this.serializeObj = JsonConvert.SerializeObject(stateList.ToArray(), Formatting.Indented) + Environment.NewLine; //Serialization for writing to json file

                File.WriteAllText(stateFile, this.serializeObj); //Function to write to JSON file
            }


        }
        
        BackUp backup = null;
        //Function
        public void LaunchUniqueSave(String backupname)//launch a unique save function sans lupdate du logFile
        {
            
            string readfile = File.ReadAllText(backupListFile);// Open the path to read from.
            if(readfile.Length !=0)
            {
                BackUp[] list = JsonConvert.DeserializeObject<BackUp[]>(readfile);
                foreach(var obj in list)
                {
                    if(obj.SaveName == backupname)
                    {
                        backup = new BackUp(obj.SaveName, obj.SourceDir, obj.TargetDir, obj.Type, obj.MirrorDir); 
                    }
                }

            }
            if (backup.Type==1)//for complete save
             {
                
             }
            else //for differential save*
            { 
                
            }

        }
        public void LaunchSequentialSave()
        {
            string readfile = File.ReadAllText(backupListFile);// Open the path to read from.
            if(readfile.Length!=0)
            {
                BackUp[] list = JsonConvert.DeserializeObject<BackUp[]>(readfile);
                foreach(var obj in list)
                {
                    
                     backup = new BackUp(obj.SaveName, obj.SourceDir, obj.TargetDir, obj.Type, obj.MirrorDir); 
                    
                }

            }
            if (backup.Type==1)//for complete save
             {
                
             }
                else //for differential save*
                { 
                
                }
        }

        public void UpdateLogFile(string savename, string sourcedir, string targetdir)//Function to allow modification of the log file
        {
        Stopwatch stopwatch = new Stopwatch();
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimeTransfert.Hours, TimeTransfert.Minutes, TimeTransfert.Seconds, TimeTransfert.Milliseconds / 10); //Formatting the stopwatch for better visibility in the file
            
        DataLog datalogs = new DataLog //Apply the retrieved values ​​to their classes

            {
                SaveName=savename,
                SourceDir = sourcedir,
                TargetDir = targetdir,
                BackupDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                TotalSize = TotalSize,
                FileTransferTime = elapsedTime// fonction for better visibility in the file in relation with stopwatch,

            };

            string path = System.Environment.CurrentDirectory; //Allows you to retrieve the path of the program environment
            var directory = System.IO.Path.GetDirectoryName(path); // This file saves in the project: \EasySaveApp\bin

            string serializeObj = JsonConvert.SerializeObject(datalogs, Formatting.Indented) + Environment.NewLine; //Serialization for writing to json file
            File.AppendAllText(directory + @"DailyLogs_" + DateTime.Now.ToString("dd-MM-yyyy") + ".json", serializeObj); //Function to write to log file
        
        }
    }
}