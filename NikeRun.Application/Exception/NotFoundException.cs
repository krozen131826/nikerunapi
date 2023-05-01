using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.Application.Exception;

public class NotFoundException : System.Exception
{
    public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found")
    {

    }
}

