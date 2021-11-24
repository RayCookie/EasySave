using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;
using System.Security.Cryptography;

namespace easysave.Models
{
    class Model
    {
        public string BackupNameState { get; set; }
        public int nbfiles { get; set; }
        public long size { get; set; }
        public DataState DataState { get; set; }
        public string userMenuInput { get; set; }
        private string serializeObj;
        public int nbfilesmax { get; set; }
        public string NameStateFile { get; set; }
        public string MirrorDir { get; set; }
        public int Type { get; set; }
        public int checkdatabackup { get; set; }
        public string SaveName { get; set; }
        public float progs { get; set; }

        public long TotalSize { get; set; }
        public TimeSpan TimeTransfert { get; private set; }

        public string backupListFile = System.Environment.CurrentDirectory + @"\\";
        public string stateFile = System.Environment.CurrentDirectory + @"\\";
        public string SourceDir { get; set; }
        public string TargetDir { get; set; }
        public Model()
        {
            userMenuInput = " ";

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
        private bool eligible(FileInfo el, DirectoryInfo dest, DirectoryInfo source)
        {
            if (File.Exists(el.FullName.Replace(source.FullName, dest.FullName)))
            {
                using (var sourcef = File.OpenRead(el.FullName))
                {
                    //on ouvre le fichier destination
                    using (var destinationf = File.OpenRead(el.FullName.Replace(source.FullName, dest.FullName)))
                    {
                        var hash1 = BitConverter.ToString(MD5.Create().ComputeHash(sourcef));//on hash le contenu du fichier source
                        var hash2 = BitConverter.ToString(MD5.Create().ComputeHash(destinationf));//on hash le contenu du fichier destination
                                                                                                  //si le hash est le meme on saute a l'itération suivante sans faire de sauvegarde
                        if (hash1 == hash2)
                        {
                            return false;
                        };
                    }
                }
            }
            return false;
        }
        public void DifferentialSave(string pathA, string pathB, string pathC) // Function that allows you to make a differential backup
        {
            //a = source
            //b=dest
            //c = mirroir
            if (File.Exists(pathA)) throw new Exception("source doesn't exist !!");
            DataState = new DataState(NameStateFile); //Instattation of the method
            Stopwatch stopwatch = new Stopwatch(); // Instattation of the stopwatch method
            stopwatch.Start(); //Starting the stopwatch

            DataState.SaveState = true;
            DataState.TotalFileSize = 0;
            nbfilesmax = 0;

            System.IO.DirectoryInfo dirsource = new System.IO.DirectoryInfo(pathA);
            System.IO.DirectoryInfo dirdest = new System.IO.DirectoryInfo(pathB);

            // Take a snapshot of the file system.  
            FileInfo[] files = (FileInfo[])dirsource.GetFiles("*", SearchOption.AllDirectories).Where(el => eligible(el, dirdest, dirsource));
            foreach (var file in files)
            {
                TotalSize += file.Length;
            }
            nbfilesmax = files.Count();
            foreach (var file in files)
            {
                string destfile = file.FullName.Replace(pathA, pathB);
                file.CopyTo(destfile, true);
                DataState.PathSourceFile = Path.Combine(pathA, file.Name);
                DataState.PathFileDestination = destfile;
                DataState.TotalFileSize = nbfilesmax;
                DataState.TotalNumberFileToCopy = TotalSize;
                DataState.SizeRemainingFile = TotalSize - size;
                DataState.NumberFileRemaining = nbfilesmax - nbfiles;
                DataState.Progression = progs;
                UpdateStatefile();
                stopwatch.Stop(); //Stop the stopwatch
                this.TimeTransfert = stopwatch.Elapsed;
            }
            ////A custom file comparer defined below  
            //FileCompare myFileCompare = new FileCompare();

            //var queryList1Only = (from file in list1 select file).Except(list2, myFileCompare);
            //size = 0;
            //nbfiles = 0;
            //progs = 0;


            ////Loop that allows the backup of different files
            //foreach (var v in queryList1Only)
            //{
            //    string tempPath = Path.Combine(pathC, v.Name);
            //    //Systems which allows to insert the values ​​of each file in the report file.


            //    UpdateStatefile();//Call of the function to start the state file system
            //    v.CopyTo(tempPath, true); //Function that allows you to copy the file to its new folder.
            //    size += v.Length;
            //    nbfiles++;
            //}

            ////System which allows the values ​​to be reset to 0 at the end of the backup
            //DataState.PathSourceFile = null;
            //DataState.PathSourceFile = null;
            //DataState.TotalNumberFileToCopy = 0;
            //DataState.TotalFileSize = 0;
            //DataState.SizeRemainingFile = 0;
            //DataState.NumberFileRemaining = 0;
            //DataState.Progression = 0;
            //DataState.SaveState = false;
            //UpdateStatefile();//Call of the function to start the state file system

            //stopwatch.Stop(); //Stop the stopwatch
            //this.TimeTransfert = stopwatch.Elapsed; // Transfer of the chrono time to the variable
        }


        public void AddSave(BackUp backup) //Function that creates a backup job
        {
            List<BackUp> backupList = new List<BackUp>();
            this.serializeObj = null;

            if (!File.Exists(backupListFile)) //Checking if the file exists
            {
                File.WriteAllText(backupListFile, this.serializeObj);
            }

            string jsonString = File.ReadAllText(backupListFile); //Reading the json file

            if (jsonString.Length != 0) //Checking the contents of the json file is empty or not
            {
                BackUp[] list = JsonConvert.DeserializeObject<BackUp[]>(jsonString); //Derialization of the json file
                foreach (var obj in list) //Loop to add the information in the json
                {
                    backupList.Add(obj);
                }
            }
            backupList.Add(backup); //Allows you to prepare the objects for the json filling

            this.serializeObj = JsonConvert.SerializeObject(backupList.ToArray(), Formatting.Indented) + Environment.NewLine; //Serialization for writing to json file
            File.WriteAllText(backupListFile, this.serializeObj); // Writing to the json file

            DataState = new DataState(this.SaveName); //Class initiation

            DataState.statedate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); //Adding the time in the variable
            AddStateFile(); //Call of the function to add the backup in the report file.
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
                    if (obj.Name == this.NameStateFile) //Verification so that the name in the json is the same as that of the backup
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
        public void LaunchUniqueSave(string backupname)//launch a unique save function sans lupdate du logFile
        {

            string readfile = File.ReadAllText(backupListFile);// Open the path to read from.
            if (readfile.Length != 0)
            {
                BackUp[] list = JsonConvert.DeserializeObject<BackUp[]>(readfile);
                foreach (var obj in list)
                {
                    if (obj.SaveName == backupname)
                    {
                        backup = new BackUp(obj.SaveName, obj.SourceDir, obj.TargetDir, obj.Type, obj.MirrorDir);
                    }
                }

            }
            if (backup.Type == 1)//for complete save
            {
                NameStateFile = backup.SaveName;
                //call the complete save function
                UpdateLogFile(backup.SaveName, backup.SourceDir, backup.TargetDir);//call the Updatelogfile function
                Console.WriteLine("complete save for the job chosen is done succesfully");
            }
            else //for differential save*
            {
                NameStateFile = backup.SaveName;
                DifferentialSave(backup.SourceDir, backup.MirrorDir, backup.TargetDir);//call the DifferentialSave function
                UpdateLogFile(backup.SaveName, backup.SourceDir, backup.TargetDir);//call the Updatelogfile function
                Console.WriteLine("differntial save for the job chosen is done succesfully");

            }

        }
        public void LaunchSequentialSave()
        {
            BackUp backup = null;
            this.TotalSize = 0;
            string readfile = File.ReadAllText(backupListFile);// Open the path to read from.
            if (readfile.Length != 0)
            {
                BackUp[] list = JsonConvert.DeserializeObject<BackUp[]>(readfile);
                foreach (var obj in list)
                {

                    backup = new BackUp(obj.SaveName, obj.SourceDir, obj.TargetDir, obj.Type, obj.MirrorDir);
                    if (backup.Type == 1)//for complete save
                    {
                        NameStateFile = backup.SaveName;
                        //call the complete save function
                        UpdateLogFile(backup.SaveName, backup.SourceDir, backup.TargetDir);//call the Updatelogfile function
                        Console.WriteLine("Complete save for all the jobs is done succesfully");
                    }
                    else //for differential save*
                    {
                        NameStateFile = backup.SaveName;
                        DifferentialSave(backup.SourceDir, backup.MirrorDir, backup.TargetDir);//call the DifferentialSave function
                        UpdateLogFile(backup.SaveName, backup.SourceDir, backup.TargetDir);//call the Updatelogfile function
                        Console.WriteLine("differntial save for all the jobs is done succesfully");
                    }
                }

            }

        }
        public void UpdateLogFile(string savename, string sourcedir, string targetdir)//Function to allow modification of the log file
        {
            Stopwatch stopwatch = new Stopwatch();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", TimeTransfert.Hours, TimeTransfert.Minutes, TimeTransfert.Seconds, TimeTransfert.Milliseconds / 10); //Formatting the stopwatch for better visibility in the file

            DataLog datalogs = new DataLog //Apply the retrieved values ​​to their classes

            {
                SaveName = savename,
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
        public void CheckDataFile()  // Function that allows to count the number of backups in the json file of backup jobs
        {
            checkdatabackup = 0;

            if (File.Exists(backupListFile)) //Check on file exists
            {
                string jsonString = File.ReadAllText(backupListFile);//Reading the json file
                if (jsonString.Length != 0)//Checking the contents of the json file is empty or not
                {
                    BackUp[] list = JsonConvert.DeserializeObject<BackUp[]>(jsonString); //Derialization of the json file
                    checkdatabackup = list.Length; //Allows to count the number of backups
                }
            }
        }
        public void LoadSave(string backupname) //Function that allows you to load backup jobs
        {
            BackUp backup = null;
            this.TotalSize = 0;
            BackupNameState = backupname;

            string jsonString = File.ReadAllText(backupListFile); //Reading the json file


            if (jsonString.Length != 0) //Checking the contents of the json file is empty or not
            {
                BackUp[] list = JsonConvert.DeserializeObject<BackUp[]>(jsonString);  //Derialization of the json file
                foreach (var obj in list)
                {
                    if (obj.SaveName == backupname) //Check to have the correct name of the backup
                    {
                        backup = new BackUp(obj.SaveName, obj.SourceDir, obj.TargetDir, obj.Type, obj.MirrorDir); //Function that allows you to retrieve information about the backup
                    }
                }
            }

            if (backup.Type == 1) //If the type is 1, it means it's a full backup
            {
                NameStateFile = backup.SaveName;
                CompleteSave(backup.SourceDir, backup.TargetDir, true, false); //Calling the function to run the full backup
                UpdateLogFile(backup.SaveName, backup.SourceDir, backup.TargetDir); //Call of the function to start the modifications of the log file
                Console.WriteLine("Saved Successfull !"); //Satisfaction message display
            }
            else //If this is the wrong guy then, it means it's a differential backup
            {
                NameStateFile = backup.SaveName;
                DifferentialSave(backup.SourceDir, backup.MirrorDir, backup.TargetDir); //Calling the function to start the differential backup
                UpdateLogFile(backup.SaveName, backup.SourceDir, backup.TargetDir); //Call of the function to start the modifications of the log file
                Console.WriteLine("Saved Successfull !"); //Satisfaction message display
            }

        }
        public void CompleteSave(string inputpathsave, string inputDestToSave, bool copyDir, bool verif) //Function for full folder backup
        {
            DataState = new DataState(NameStateFile);
            this.DataState.SaveState = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //Starting the timed for the log file

            DirectoryInfo dir = new DirectoryInfo(inputpathsave);  // Get the subdirectories for the specified directory.

            if (!dir.Exists) //Check if the file is present
            {
                throw new DirectoryNotFoundException("ERROR 404 : Directory Not Found ! " + inputpathsave);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(inputDestToSave); // If the destination directory doesn't exist, create it.

            FileInfo[] files = dir.GetFiles(); // Get the files in the directory and copy them to the new location.

            if (!verif) //  Check for the status file if it needs to reset the variables
            {
                TotalSize = 0;
                nbfilesmax = 0;
                size = 0;
                nbfiles = 0;
                progs = 0;

                foreach (FileInfo file in files) // Loop to allow calculation of files and folder size
                {
                    TotalSize += file.Length;
                    nbfilesmax++;
                }
                foreach (DirectoryInfo subdir in dirs) // Loop to allow calculation of subfiles and subfolder size
                {
                    FileInfo[] Maxfiles = subdir.GetFiles();
                    foreach (FileInfo file in Maxfiles)
                    {
                        TotalSize += file.Length;
                        nbfilesmax++;
                    }
                }

            }

        }
    }
}