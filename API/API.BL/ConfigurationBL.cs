using API.BL.Entities;
using Infrastructure.Database;
using Infrastructure.Interfaces;
using System.Collections.Generic;

namespace API.BL
{
    public class ConfigurationBL : IConfigurationBL
    {
        private readonly IRepositoryManager _repo;
        
        public ConfigurationBL(IRepositoryManager repo)
        {
            _repo = repo;
        } 

        public List<SystemConfiguration> GetAllConfigurationData()
        {
            var configurationRepo = _repo.GetRepository<SystemConfiguration>(DataAccessProviderTypes.SqlServer);
            List<SystemConfiguration> systemconfigurations = configurationRepo.GetAll("GetAllConfigurationData");

            return systemconfigurations;
        }

        public void InsertConfigurationData()
        {
            SystemConfiguration s = new SystemConfiguration();
            s.SortOrder = 1;
            s.CurrentValue = "test";
            s.PreviousValue = "test123";

            SystemConfigurationCategory sc = new SystemConfigurationCategory();
            sc.NameResourceKey = "testkey";
            sc.SortOrder = 1;
            
            _repo.BeginTransaction();
            try
            {
                var configurationRepo = _repo.GetRepository<SystemConfiguration>(DataAccessProviderTypes.SqlServer);
                configurationRepo.Insert(s, "InsertConfigurationData");

                var configuration1Repo = _repo.GetRepository<SystemConfigurationCategory>(DataAccessProviderTypes.SqlServer);
                configuration1Repo.Insert(sc, "InsertConfigurationTypeData");
                _repo.Commit();
            }
            catch (System.Exception)
            {
                _repo.Rollback();
                _repo.Dispose();
            }
        }
    }
}
