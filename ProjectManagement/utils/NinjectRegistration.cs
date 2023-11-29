using BLL;
using BLL.Interfaces;
using Ninject.Modules;

namespace ProjectManagement.utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IAddProjectService>().To<AddProjectService>();
            Bind<IDbCrud>().To<DbDataOperations>();
        }
    }
}
