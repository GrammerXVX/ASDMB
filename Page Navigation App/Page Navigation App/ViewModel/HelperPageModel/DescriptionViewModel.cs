using Microsoft.EntityFrameworkCore;
using Page_Navigation_App.Model.DataBaseModel;
using Page_Navigation_App.Model.Entity;
using Page_Navigation_App.Model.TemplateDataSevice;
using Page_Navigation_App.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.ViewModel.HelperPageModel
{
    public class DescriptionViewModel : ViewModelBase
    {
		private string decription;
        private readonly BeltelecomDirectoryContext _context;
        public string Description
		{
			get { return  decription; }
			set { SetProperty(ref decription,value,nameof(Description)); }
		}
        public string[] Options { get; set; }
        public DescriptionViewModel(object id)
        {
            Options = new string[3];
            _context = new BeltelecomDirectoryContext();
            var description = _context.Descriptions.FirstOrDefault(x => x.DescriptionId == (id as Button_Service).Service.ServiceId);

            if (description == null)
            {
                Description = "Отсутствует";
                Options = new[] { "Отсутствует", "Отсутствует", "Отсутствует" };
            }
            else
            {
                Description = description.Description1;
                Options = new[] { description.SpecialNote1, description.SpecialNote2, description.SpecialNote3 };
            }
        }
		public DescriptionViewModel() { }

	}
}
