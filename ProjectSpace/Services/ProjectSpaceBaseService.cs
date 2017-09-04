using ProjectSpace.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSpace.Services
{
    public abstract class BaseService :  IRequireContext
    {
        protected ExecutionContext Context { get; private set; }

        public abstract void Dispose();

        public abstract void SaveChanges();

        void IRequireContext.SetContext(ExecutionContext context)
        {
            this.Context = context;
        }
    }
}
