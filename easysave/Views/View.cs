using System;
using System.Collections.Generic;
using System.Text;


namespace easysave.view
{
    class View
    {
        public void Welcome()
        {
            Console.WriteLine(" _________________________________________________________________________ ");
            Console.WriteLine("| ____|     /   | /  ___/ | |  / /      /  ___/     /   | | |   / / | ____|");
            Console.WriteLine("| |__      / /| | | |___   | |/ /       | |___     / /| | | |  / /  | |__  ");
            Console.WriteLine("|  __|    / / | | |___  |   |  /         ____     / / | | | | / /   |  __| ");
            Console.WriteLine("| |___   / /  | |  ___| |   / /          ___| |  / /  | | | |/ /    | |___ ");
            Console.WriteLine("|_____| /_/   |_| /_____/  /_/          /_____/ /_/   |_| |___/     |_____|");
        }

        public void Language()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++______________++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++____|              |_____++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++|    Choose a language    |+++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++ |   choisissez une langue |+++++++++++++++++++++++++++");
            Console.WriteLine(" _________________________|                         |__________________________ ");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                          1 +-----French/Français----+----+                   |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                          2 +-----English/englais-----+----+                  |");
            Console.WriteLine("|_________________________                           _________________________ |");
            Console.WriteLine("+++++++++++++++++++++++++ |                         |+++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++ |                         |+++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++|_________________________|+++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            
        }

        public void DisplayMenu()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++______________++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++____|              |_____++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++|                         |+++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++ |           Menu          |+++++++++++++++++++++++++++");
            Console.WriteLine(" _________________________|                         | _________________________");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                     0 +-------------Exit--------+----------+                 |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                     1 +------Execute a backup job-----+----+                 |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                     2 +------Create a backup job-----+-----+                    |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|_________________________                               _____________________ |");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|    Please enter a number    |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|_____________________________|");
        }

        public void DisplaySubMenu()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++______________+++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++_____|              |_____+++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++|                          |++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++ |      Backup Jobs         |++++++++++++++++++++++++++");
            Console.WriteLine(" _________________________|                          | _________________________");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                     0 +------------Exit--------+--------+                     |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                     1 +--------Complete Save--------+----+                    |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                     2 +------Differential Save-----+----+                     |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|_________________________                               ______________________ |");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|    Please enter a number    |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|_____________________________|");
        }

        public void ShowSourcePath()
        {
            Console.WriteLine("+--------------------------------------------------------+");
            Console.WriteLine("|                                                        |");
            Console.WriteLine("|Please enter the path of the folder you want to back up.|");
            Console.WriteLine("|                                                        |");
            Console.WriteLine("+ ---------+---------------------------------------------+");
        }

        public void ShowTargetPath()
        {
            Console.WriteLine("+-------------------------------------------------+");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|Please enter the destination path for the backup.|");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("+ ---------+--------------------------------------+");
        }

        public void ShowMirrorPath()
        {
            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|Please enter the path of the folder mirror backup.|");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("+ ---------+---------------------------------------+");
        }

        public void ShowFile()
        {
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("|                                     |");
            Console.WriteLine("|Please enter the name of your backup.|");
            Console.WriteLine("|                                     |");
            Console.WriteLine("+ ---------+--------------------------+");
        }


        public void ShowNameFile()
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("|                                     |");
            Console.WriteLine("|Here are the names of your backups.  |");
            Console.WriteLine("|                                     |");
            Console.WriteLine("+ ---------+--------------------------+");
        }

        public void ErrorMenu(string result)
        {
            Console.WriteLine("+-----------------+-------------------+");
            Console.WriteLine("|                                     |");
            Console.WriteLine("|"             +result+ "             |");
            Console.WriteLine("|                                     |");
            Console.WriteLine("+ ----------------+-------------------+");
        }
    }
}