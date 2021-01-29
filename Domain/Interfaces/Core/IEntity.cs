using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Core
{
    public interface IEntity
    {
        SystemFields SystemFields { get; set; }
    }
}
