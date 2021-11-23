using System;
using System.Collections.Generic;
using System.Text;


namespace easysave.view
{
    class View
    {

        public void Languuage()
        {
            Console.WriteLine("***   Choose a language      ***");
            Console.WriteLine("***   1.Francais             ***");
            Console.WriteLine("***   2.Anglais              ***");
        }

        public void DisplayMenu()
        {
            Console.WriteLine("***                    Menu                      ***");
            Console.WriteLine("****************************************************");
            Console.WriteLine("***            0. Exit                           ***");
            Console.WriteLine("***            1. Execute a backup job           ***");
            Console.WriteLine("***            2. Create a backup job            ***");
            Console.WriteLine("****************************************************");
            Console.Write("Please enter a number : ");
        }

        public void DisplayMenu2()
        {

            Console.WriteLine("***                 Backup Jobs                  ***");
            Console.WriteLine("****************************************************");
            Console.WriteLine("***  0. Exit                                     ***");
            Console.WriteLine("***  1. Complete Save                            ***");
            Console.WriteLine("***  2. Differential Save                        ***");
            Console.WriteLine("****************************************************");
            Console.Write("Please enter a number : ");
        }


        public void ShowSourcePath()
        {
            Console.WriteLine("Please enter the path of the folder you want to back up.");
        }

        public void ShowTargetPath()
        {
            Console.WriteLine("Please enter the destination path for the backup.");
        }

        public void ShowNewPath()
        {
            Console.WriteLine("Please enter the path of the folder mirror backup. [ DRAG AND DROP YOUR FOLDER ] :");
        }

        public void ShowFile()
        {
            Console.Write("Please enter the name of your backup : ");
        }

        public void ShowNameFile()
        {
            Console.Clear();
            Console.WriteLine("Here are the names of your backups : ");
        }
        public void ErrorMenu(string result)
        {
            Console.WriteLine(result);
        }



    }
}