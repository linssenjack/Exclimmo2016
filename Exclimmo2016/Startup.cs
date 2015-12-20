using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exclimmo2016.Startup))]
namespace Exclimmo2016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
