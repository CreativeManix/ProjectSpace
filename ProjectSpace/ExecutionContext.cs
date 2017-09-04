using ProjectSpace.Core;
using ProjectSpace.Entities;
using ProjectSpace.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;

namespace ProjectSpace
{
    public class ExecutionContext : IDisposable
    {
        private Scope containerScope;


        //Constructor is private so no instance can be created outside this class
        private ExecutionContext()
        {
            containerScope=ThreadScopedLifestyle.BeginScope(AppContainer.Current);
        }

        public ExecutionContextCommitType CommitType { get; set; }
        public static ExecutionContext New()
        {
            return new ExecutionContext() { CommitType=ExecutionContextCommitType.Implicit};
        }

        public static ExecutionContext New(ExecutionContextCommitType commitType)
        {
            
            return new ExecutionContext() { CommitType = commitType };
        }


        List<BaseService> services = new List<BaseService>();

        public T Get<T>() where T : class
        {
            T s = AppContainer.Current.GetInstance<T>();
            IRequireContext iNeedContext = s as IRequireContext;
            if(iNeedContext!=null)
                iNeedContext.SetContext(this);
            return s;
        }

        public ApplicationEntities App { get; }
        private void SaveContext()
        {
            foreach (var service in services)
            {
                service.SaveChanges();
            }
        }

        public void Dispose()
        {
            if (CommitType == ExecutionContextCommitType.Implicit) SaveContext();

            containerScope.Dispose();
        }
    }
}
