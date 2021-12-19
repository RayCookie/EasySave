using System;
using System.Collections.Generic;
using System.Text;
using Version03.Models;
using System.IO;

using Newtonsoft.Json;

namespace Version03.ViewModel
{
    class viewmodel
    {
        int langue = 0;
        private model model;
        public viewmodel()
        {

            model = new model();

        }

        public void MenuSub(string FileName, string Source, string destination, int type, string Mirror) //Function for backUp add.
        {
            model.SaveName = FileName;
            Backup backup = new Backup(FileName, Source, destination, type, Mirror);
            model.AddSave(backup);
        }
        public List<string> ListBackup()//Function that lets you know the lists of the names of the backups.
        {

            List<string> nameslist = new List<string>();
            foreach (var obj in model.NameList())
            {
                nameslist.Add(obj.SaveName);
            }
            return nameslist;
        }
        public void loadSave(string FileName)
        {
            model.SaveName = FileName;
            model.Parallelle(FileName);
        }
        public void pause()
        {
            model.pause();
        }
        public void stop()
        {
            model.stop();
        }
    }
}
