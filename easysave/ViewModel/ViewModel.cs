using System;
using System.IO;
using System.Diagnostics;
using easysave.Model;
using easysave.view;
using Newtonsoft.Json;

namespace easysave.ViewModel
{
    class ViewModel
    {
        private model model;
        private View view;
        private int inputMenu;

        public ViewModel()
        {
            model = new model();
            view = new View();
            view.ShowStart(); //Function call
            model.userMenuInput = Menu(); //Function call

        }

        private string GetSourceDir() //Function to retrieve the input from the source
        {
            string sourceDir = "";
            bool isValid = false;

            while (!isValid) //Loop to allow verification of the path
            {
                sourceDir = Console.ReadLine(); //Retrieving user input
                if (Directory.Exists(sourceDir.Replace("\"", ""))) //Remplace \ for ""
                {
                    isValid = true;
                }
                else
                {
                    view.ErrorMenu("Incorect Path"); //Show error message
                }

            }
            return sourceDir;
        }
        private string GetTargetDir() //Function to retrieve the input from the destination repesetory
        {
            string targetDir = "";
            bool isValid = false;

            while (!isValid)//Loop to allow verification of the path
            {
                targetDir = Console.ReadLine();// Retrieving user input
                if (Directory.Exists(targetDir.Replace("\"", "")))  //Remplace \ for ""
                {
                    isValid = true;
                }
                else
                {
                    view.ErrorMenu("Incorect Path"); //Show error message
                }

            }
            return targetDir;
        }

        private string GetMirrorDir() //Function to retrieve folder entry from full backup
        {
            string mirrorDir = "";
            bool isValid = false;

            while (!isValid)//Loop to allow verification of the path
            {
                mirrorDir = Console.ReadLine();// Retrieving user input
                if (Directory.Exists(mirrorDir.Replace("\"", "")))//Remplace \ for ""
                {
                    isValid = true;
                }
                else
                {
                    view.ErrorMenu("Incorect Path");//Show error message
                }

            }
            return mirrorDir;
        }

        private string Menu() //function for menu management
        {
            Stopwatch stopwatch = new Stopwatch();
            bool menu = true;
            while (menu) //Loop for menu
            {
                model.CheckDataFile(); // Calling the function to check the number of backups
                try
                {
                    view.ShowMenu(); //Calling the function to display the menu
                    inputMenu = int.Parse(Console.ReadLine()); //Retrieving user input for menu
                    switch (inputMenu) // Switch of menu
                    {
                        case 0:
                            Environment.Exit(0); //Stop the programs
                            break;
                        case 1:
                            view.ShowNameFile(); //Display message introduction on the backup names

                            string jsonString = File.ReadAllText(model.backupListFile); //Function to read json file
                            Backup[] list = JsonConvert.DeserializeObject<Backup[]>(jsonString); // Function to dezerialize the json file

                            foreach (var obj in list) //Loop to display the names of the backups
                            {
                                Console.WriteLine(" - " + obj.SaveName); //Display of backup names
                            }


                            view.showLaunchType();
                            int inputLanchType = int.Parse(Console.ReadLine());
                            if (inputLanchType == 1)
                            {
                                view.ShowFile();//Calling the function to display the names of the backups
                                string inputnamebackup = Console.ReadLine(); // Recovering backup names
                                model.LoadUniqueSave(inputnamebackup); // Calling the function to start the backup
                            }
                            else
                            {
                                model.LaunchSequentialSave();
                            }
                            break;

                        case 2:
                            if (model.checkdatabackup < 5) // Check not to exceed the save limit
                            {
                                Console.Clear(); //Console cleaning
                                view.ShowSubMenu(); // Calling the function to display the second menu
                                MenuSub(); // Calling the function for the second menu
                            }
                            else
                            {
                                Console.Clear(); //Console cleaning
                                view.ErrorMenu("You already have 5 backups to create."); // Show Error Message
                            }

                            break;
                    }

                }
                catch
                {
                    Console.Clear();//Console cleaning
                }

            }

            return "";
        }

        private void MenuSub() //Function for the menu when creating backup jobs.
        {
            bool menusub = true;
            while (menusub) //Loop for menu
            {
                try
                {
                    int inputMenuSub = int.Parse(Console.ReadLine()); //Retrieving user input for second menu
                    switch (inputMenuSub) // Switch of menu
                    {
                        case 0:
                            Console.Clear();//Console cleaning
                            Menu(); //Calling up the menu function
                            break;
                        case 1: //Case 1, creating a full backup job
                            model.Type = 1; //Type declaration for backup
                            view.ShowName(); //Display for backup name
                            model.SaveName = Console.ReadLine(); // Retrieving the name of the backup
                            view.ShowSourceDir(); // Display for folder source
                            model.SourceDir = GetSourceDir(); // Function for checking the folder path
                            view.ShowTargetDir(); // Display for the folder destination
                            model.TargetDir = GetTargetDir();  // Function for checking the folder path
                            Backup backup = new Backup(model.SaveName, model.SourceDir, model.TargetDir, model.Type, "");
                            model.AddSave(backup); // Calling the function to add a backup job
                            Console.WriteLine("added with success ,press enter to go back to principal Menu");
                            break;

                        case 2: //Case 2, creating a differential backup job
                            model.Type = 2; //Type declaration for backup
                            view.ShowName();
                            model.SaveName = Console.ReadLine();
                            view.ShowSourceDir();
                            model.SourceDir = GetSourceDir();
                            view.ShowMirrorDir();
                            model.MirrorDir = GetMirrorDir();
                            view.ShowTargetDir();
                            model.TargetDir = GetTargetDir();
                            Backup backup2 = new Backup(model.SaveName, model.SourceDir, model.TargetDir, model.Type, model.MirrorDir);
                            model.AddSave(backup2); // Calling the function to add a backup job
                            break;
                    }

                }
                catch
                {
                    Console.Clear();
                    Menu(); //Calling up the menu function
                }

            }

        }
    }
}
