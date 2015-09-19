
namespace DemoTurma480.DataEF.Config.Provider
{
    public class SetProviderEF : System.Data.Entity.DbConfiguration
    {
        public SetProviderEF()
        {

            SetProviderServices(
                           System.Data.Entity.SqlServer.SqlProviderServices.ProviderInvariantName,
                           System.Data.Entity.SqlServer.SqlProviderServices.Instance
                           );

        }
    }
}

