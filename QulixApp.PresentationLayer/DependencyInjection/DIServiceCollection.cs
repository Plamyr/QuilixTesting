using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class DIServiceCollection
    {
        private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();
        public DIContainer CreateContainer()
        {
            return new DIContainer(_serviceDescriptors);
        }

        public void RegisterSingleton<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor())
        }
    }
}
