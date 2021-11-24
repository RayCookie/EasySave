using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using easysave.Models;
using easysave.view;

namespace easysave.ViewModel
{
    class ViewModel
    {
        private View view;
        private Model model;

        public  ViewModel()
        {
            model = new Model();
            view = new View();
            view.Welcome(); //Function call of welcome Menu
            //model.UserCHoice = Menu(); //Function call

        }
    }
}
