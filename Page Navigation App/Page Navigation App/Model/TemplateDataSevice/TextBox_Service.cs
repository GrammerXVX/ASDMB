using Microsoft.IdentityModel.Tokens;
using Page_Navigation_App.Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.Model.TemplateDataSevice
{
    public class TextBox_Service : Button_Service
    {
        private string leftLimit;
        public string LeftLimit
        {
            get => leftLimit;
            set
            {
                _ = int.TryParse(value, out int num);
                if (isLimit)
                {
                    if (num < Limits[0])
                        num = Limits[0];
                    if (num >= Limits[1])
                        num = Limits[1] - 1;
                }
                Limits[2]=num;
                leftLimit = num.ToString();
            }
        }
        private string rightLimit;
        public string RightLimit
        {
            get => rightLimit;
            set
            {
                _ = int.TryParse(value, out int num);
                if (isLimit)
                    if (num > Limits[1] || num <= Limits[0])
                        num = Limits[1];
                Limits[3] = num;
                rightLimit = num.ToString();
            }
        }
        private int[] Limits;
        private bool isLimit;
        public TextBox_Service(int MinValue,int MaxValue)
        {
            Limits =  new int[4] { MinValue, MaxValue,0,0};
            isLimit = true;
        }
        public TextBox_Service()
        {
            isLimit = false;
        }

        public ObservableCollection<Button_Service> BeingInBetween(ObservableCollection<Button_Service> Data)
        {
            var newData = new ObservableCollection<Button_Service>();
            foreach (var DataItem in Data)
            {
                if (DataItem.Service.Price >= Limits[2]&& DataItem.Service.Price <= Limits[3])
                { 
                    newData.Add(DataItem); 
                }
            }
            newData= new ObservableCollection<Button_Service>(newData.OrderBy(x => x.Service.Price).ToList());
            return newData;
        }
    }
}
