﻿namespace UniversitySystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public abstract class BaseModel
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();

    }
}
