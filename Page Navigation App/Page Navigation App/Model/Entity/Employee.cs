using System;
using System.Collections.Generic;

namespace Page_Navigation_App.Model.Entity;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UniqueNumber { get; set; }

    public int PositionId { get; set; }

    public int DepartmentId { get; set; }

    public DateTime? BirthDate { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public virtual Department Department { get; set; }

    public virtual Position Position { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
