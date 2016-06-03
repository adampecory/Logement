using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonLogement.Startup))]
namespace MonLogement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
