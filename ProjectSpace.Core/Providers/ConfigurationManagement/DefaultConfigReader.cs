using ProjectSpace.Core.ConfigurationManagement;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ProjectSpace.Core.Providers.ConfigurationManagement
{
    public class DefaultConfigReader : IConfigReader
    {
        IConfiguration config = null;
        public DefaultConfigReader(IConfiguration config)
        {
            this.config = config;
        }

        public string GetSetting(string key)
        {
            return config[key];
        }
    }
}
