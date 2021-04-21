using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; set; }
        public object Implementation { get; set; }

        public ServiceDescriptor(object implementation)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;
        }

        public ServiceDescriptor(Type serviceType)
        {
            ServiceType = serviceType;
        }
    }
}
