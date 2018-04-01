using System;
using Microsoft.Extensions.DependencyInjection;

namespace cvtemplate
{
    public class LiteDbConfiguration
    {
        private ServiceProvider serviceProvider;

        public LiteDbConfiguration(ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Build()
        {

        }
    }
}
