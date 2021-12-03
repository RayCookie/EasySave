using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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

        public void MenuSub(string FileName, string Source, string destination, int type, string Mirror) //Function for the menu when creating backup jobs.
        {
            model.SaveName = FileName;
            Backup backup = new Backup(FileName, Source, destination, type, Mirror);
            model.AddSave(backup);
        }
    }
}
