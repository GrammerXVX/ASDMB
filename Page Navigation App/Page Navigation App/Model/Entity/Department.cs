using System;
using System.Collections.Generic;

namespace Page_Navigation_App.Model.Entity;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; }

    public string DepartmentStreet { get; set; }

    public string DepartmentCity { get; set; }

    public string DepartmentSpecification { get; set; }

    public string DepartmentPhoneNumber { get; set; }

    public int EmployeeCount { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
