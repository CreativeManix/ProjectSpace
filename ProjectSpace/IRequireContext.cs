using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSpace
{
    public interface IRequireContext
    {
        void SetContext(ExecutionContext context);
    }
}
