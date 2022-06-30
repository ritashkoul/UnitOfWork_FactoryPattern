using API.BL.Entities;
using System.Collections.Generic;

namespace API.BL
{
    public interface IConfigurationBL
    {
        List<SystemConfiguration> GetAllConfigurationData();
        void InsertConfigurationData();
    }
}
