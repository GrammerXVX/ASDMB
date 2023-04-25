using System;
using System.Collections.Generic;

namespace Page_Navigation_App.Model.Entity;

public partial class Unit
{
    public int UnitId { get; set; }

    public string UnitName { get; set; }

    public string UnitDescription { get; set; }

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
