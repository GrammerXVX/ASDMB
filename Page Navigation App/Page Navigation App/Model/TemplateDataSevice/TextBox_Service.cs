using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.Model.TemplateDataSevice
{
    public class TextBox_Service : Button_Service
    {
        private StringBuilder text;
        public string Text 
        {
            get => text.ToString();
            set => text = new StringBuilder(value);
        }
        public TextBox_Service()
        {

        }
    }
}
