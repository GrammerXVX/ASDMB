using System;
using System.Collections.Generic;

namespace Page_Navigation_App.Model.Entity;

public partial class Description
{
    public int DescriptionId { get; set; }

    public string SpecialNote1 { get; set; }

    public string SpecialNote2 { get; set; }

    public string SpecialNote3 { get; set; }

    public string Description1 { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
