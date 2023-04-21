using System;
using System.Collections.Generic;

namespace Page_Navigation_App.Model.Entity;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryType { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
