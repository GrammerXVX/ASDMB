using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Page_Navigation_App.Utilities.Template
{
    public class DefaultBtn : Button
    {
        static DefaultBtn()=>
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DefaultBtn), new FrameworkPropertyMetadata(typeof(DefaultBtn)));
    }
}
