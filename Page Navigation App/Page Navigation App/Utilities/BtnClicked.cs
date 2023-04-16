using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Page_Navigation_App.Utilities
{
    public class BtnClicked : Button
    {
        static BtnClicked(){

            DefaultStyleKeyProperty.OverrideMetadata(typeof(BtnClicked), new FrameworkPropertyMetadata(typeof(BtnClicked)));
        }
}
}
