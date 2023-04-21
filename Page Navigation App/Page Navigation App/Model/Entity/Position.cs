using System;
using System.Collections.Generic;

namespace Page_Navigation_App.Model.Entity;

public partial class Position
{
    public int PositionId { get; set; }

    public string PositionName { get; set; }

    public string PositionDescription { get; set; }

    public int UnitId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Unit Unit { get; set; }
}
