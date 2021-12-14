using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using WpfPROJECT.Models;

namespace WpfPROJECT.ViewModel
{
    class viewmodel
    {
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
            model.LoadUniqueSave(FileName);
        }
    }
}
