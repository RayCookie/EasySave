using System;


namespace easysave.view
{
    class View
    {
        //Display on the console a welcome message
        public void ShowStart()
        {
            Console.WriteLine(" _________________________________________________________________________ ");
            Console.WriteLine("| ____|     /   | /  ___/ | |  / /      /  ___/     /   | | |   / / | ____|");
            Console.WriteLine("| |__      / /| | | |___   | |/ /       | |___     / /| | | |  / /  | |__  ");
            Console.WriteLine("|  __|    / / | | |___  |   |  /         ____     / / | | | | / /   |  __| ");
            Console.WriteLine("| |___   / /  | |  ___| |   / /          ___| |  / /  | | | |/ /    | |___ ");
            Console.WriteLine("|_____| /_/   |_| /_____/  /_/          /_____/ /_/   |_| |___/     |_____|");
        }
        //Display on the console the menu
        public void Language()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++______________++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++____|              |_____++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++|                         |+++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++ |           Language      |+++++++++++++++++++++++++++");
            Console.WriteLine(" _________________________|                         | _________________________");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                     1 +------english/englais-----+----+                      |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                     2 +------franch/français-----+-----+                     |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|_________________________                               _____________________ |");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("+++++++++++++++++++++++++ |    Entrez un chiffre        |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|    Please enter a number    |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|_____________________________|");
        }
        public void ShowMenu()
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
        public void montereMenu()
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++______________++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++____|              |_____++++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++|                         |+++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++ |           Menu          |+++++++++++++++++++++++++++");
            Console.WriteLine(" _________________________|                         | _________________________");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                     0 +-------------quitter--------+----------+              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                     1 +------Executer un travail-----+----+                  |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|                     2 +------creer un travail-----+-----+                    |");
            Console.WriteLine("|                                                                              |");
            Console.WriteLine("|_________________________                               _____________________ |");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|    choisisser un numéro     |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|_____________________________|");
        }
        //Display on the console the menu of backup jobs
        public void ShowSubMenu()
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
        //Display on the console when you enter the name of the save
        public void ShowName()
        {
            Console.WriteLine("+--------------------------------------------------------+");
            Console.WriteLine("|                                                        |");
            Console.WriteLine("|Please enter the Name of the folder you want to back up.|");
            Console.WriteLine("|                                                        |");
        }
        public void VoirName()
        {
            Console.WriteLine("+--------------------------------------------------------------+");
            Console.WriteLine("|                                                              |");
            Console.WriteLine("|Veuillez entrer le Nom du dossier que vous voulez sauvegarder.|");
            Console.WriteLine("|                                                              |");
        }
        //Display on the console when you have to enter the path of the folder that you want to back up
        public void ShowSourceDir()
        {
            Console.WriteLine("+--------------------------------------------------------+");
            Console.WriteLine("|                                                        |");
            Console.WriteLine("|Please enter the path of the folder you want to back up.|");
            Console.WriteLine("|                                                        |");
            Console.WriteLine("+ ---------+---------------------------------------------+");
        }
        //Display on the console when you have to enter the path of the folder that you want to back up
        public void ShowTargetDir()
        {
            Console.WriteLine("+-------------------------------------------------+");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|Please enter the destination path for the backup.|");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("+ ---------+--------------------------------------+");
        }

        public void ShowMirrorDir()
        {
            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|Please enter the path of the folder mirror backup.|");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("+ ---------+---------------------------------------+");
        }
        //Display on the console an error message
        public void ErrorMenu(string result)
        {
            Console.WriteLine(result);
        }
        //Display on the console when you have to enter the name of backup
        public void ShowFile()
        {
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("|                                     |");
            Console.WriteLine("|Please enter the name of your backup.|");
            Console.WriteLine("|                                     |");
            Console.WriteLine("+ ---------+--------------------------+");
        }
        //Display on the console when you have to enter the name of backups
        public void ShowNameFile()
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("|                                     |");
            Console.WriteLine("|Here are the names of your backups.  |");
            Console.WriteLine("|                                     |");
            Console.WriteLine("+ ---------+--------------------------+");
        }
        public void showLaunchType()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++______________+++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++_____|              |_____+++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++|                          |++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++ |      Backup Jobs         |++++++++++++++++++++++++++");
            Console.WriteLine(" _________________________|                          | _________________________");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                     1 +--------unique save--------+----+                    |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                     2 +------Sequential Save-----+----+                     |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|_________________________                               ______________________ |");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|    Please enter a number    |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|_____________________________|");

        }
        public void VoirSubMenu()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++______________+++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++_____|              |_____+++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++|                          |++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++ |    Travaux de Sauvegarde |++++++++++++++++++++++++++");
            Console.WriteLine(" _________________________|                          | _________________________");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                     0 +------------Sortir--------+--------+                     |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                     1 +--------Sauvegarde Complete--------+----+                    |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                     2 +------Sauvegarde Differentielle-----+----+                     |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|_________________________                               ______________________ |");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|    Entrez un chiffre        |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|_____________________________|");
        }


        public void VoirSourceRoute()
        {
            Console.WriteLine("+--------------------------------------------------------+");
            Console.WriteLine("|                                                        |");
            Console.WriteLine("|Veuillez entrer le chemin du dossier que vous voulez sauvegarder.|");
            Console.WriteLine("|                                                        |");
            Console.WriteLine("+ ---------+---------------------------------------------+");
        }




        public void VoirTargetRoute()
        {
            Console.WriteLine("+-------------------------------------------------+");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("|Veuillez entrer le chemin de destination de la sauvegarde.|");
            Console.WriteLine("|                                                 |");
            Console.WriteLine("+ ---------+--------------------------------------+");
        }


        public void VoirMirrorRoute()
        {
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|                                                             |");
            Console.WriteLine("|Veuillez entrer le chemin du dossier de la sauvegarde miroir.|");
            Console.WriteLine("|                                                             |");
            Console.WriteLine("+ ---------+--------------------------------------------------+");
        }

        public void VoirFile()
        {
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("|                                           |");
            Console.WriteLine("|Veuillez entrer le nom de votre sauvegarde.|");
            Console.WriteLine("|                                           |");
            Console.WriteLine("+ ---------+--------------------------------+");
        }

        public void VoirNameFile()
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("|                                     |");
            Console.WriteLine("|Les noms de vos traveaux de sauvegarde.  |");
            Console.WriteLine("|                                     |");
            Console.WriteLine("+ ---------+--------------------------+");
        }
        public void voirLaunchType()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++______________+++++++++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++_____|              |_____+++++++++++++++++++++++++++");
            Console.WriteLine("++++++++++++++++++++++++++|                          |++++++++++++++++++++++++++");
            Console.WriteLine("+++++++++++++++++++++++++ |   Traveaux de sauvegarde |++++++++++++++++++++++++++");
            Console.WriteLine(" _________________________|                          | _________________________");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                     1 +--------Sauvegarde unique--------+----+                |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|                     2 +------Sauvegarde séquentiel-----+----+                 |");
            Console.WriteLine("|                                                                               |");
            Console.WriteLine("|_________________________                               ______________________ |");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("+++++++++++++++++++++++++ |                             |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|    Entrez un chiffre        |++++++++++++++++++++++|");
            Console.WriteLine("++++++++++++++++++++++++++|_____________________________|");

        }

    }
}
