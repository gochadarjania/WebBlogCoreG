using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Core
{
    public interface ILoginProvider
    {
        int GetLoggedUserID();
    }
}
