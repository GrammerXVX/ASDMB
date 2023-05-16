using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.Model
{
    public class Button
    {
        private string serviceName;
        public string ServiceName {
            get => serviceName;
            set
            {
                serviceName = value.Split(' ').Length == 2 ? value.Replace(" ", "\n") : value+"\n";
            }
        }
        private readonly string PathSourceImg = "..\\..\\Images\\";
        
        private string imgSource;
        public string ImgSource {
            get => imgSource; 
            set =>imgSource=PathSourceImg+value+".png";
        }
        
        private string serviceCount;
        public string ServiceCount
        {
            get => serviceCount;
            set => serviceCount = "\nУслуг: "+value;
        }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
