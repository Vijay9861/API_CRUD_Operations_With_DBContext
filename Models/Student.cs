using System;
using System.Collections.Generic;

namespace NewAPI.Models;

public partial class Student
{
    public int StdId { get; set; }

    public string? StdName { get; set; }

    public int? Age { get; set; }

    public string? City { get; set; }
}
