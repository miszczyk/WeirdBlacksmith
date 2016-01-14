using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeirdBlacksmith.Startup))]
namespace WeirdBlacksmith
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
