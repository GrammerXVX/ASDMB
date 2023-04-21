using System;
using System.Collections.Generic;

namespace Page_Navigation_App.Model.Entity;

public partial class User
{
    public int UserId { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public int EmployeeId { get; set; }

    public string Role { get; set; }

    public virtual Employee Employee { get; set; }
}
