using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSpace.Core.ConfigurationManagement
{
    public interface IConfigReader
    {
        string GetSetting(string key);
    }
}
