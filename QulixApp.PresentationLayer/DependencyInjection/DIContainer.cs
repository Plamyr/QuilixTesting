using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection
{
    public class DIContainer
    {
        private List<ServiceDescriptor> _serviceDescriptors;
        public DIContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public T GetService<T>()
        {
            var descriptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == typeof(T));

            if (descriptor != null)
            {
                return (T)descriptor.Implementation;
            }
            var implementation =  (T)Activator.CreateInstance(descriptor.ServiceType);

            descriptor.Implementation = implementation;
            return implementation;
        }
    }
}
