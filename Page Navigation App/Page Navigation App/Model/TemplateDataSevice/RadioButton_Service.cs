using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.Model.TemplateDataSevice
{
    public class RadioButton_Service : Button_Service
    {
        public string Content { get; set; }
        public bool IsSelected { get; set; }
    }
}
