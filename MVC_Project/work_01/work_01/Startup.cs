using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(work_01.Startup))]
namespace work_01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
