﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Web;
using Ninject.Web.Common;
using Ninject.Syntax;

namespace dnn_webapi.Infrastructure
{
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(kernel);
        }
    }

    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot resolutionRoot;

        public NinjectScope(IResolutionRoot kernel)
        {
            resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            if (resolutionRoot == null)
                throw new ObjectDisposedException("resolutionRoot", "Dependency scope already disposed");

            return resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolutionRoot == null)
                throw new ObjectDisposedException("resolutionRoot", "Dependency scope already disposed");

            return resolutionRoot.GetAll(serviceType);
        }

        public void Dispose()
        {

        }
    }
}