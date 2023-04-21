using System;
using System.Collections.Generic;

namespace Page_Navigation_App.Model.Entity;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; }

    public string ServiceDescription { get; set; }

    public decimal Price { get; set; }

    public bool? ServiceCategoryType { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }
}
