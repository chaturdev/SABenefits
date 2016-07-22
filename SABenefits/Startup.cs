using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SABenefits.Startup))]
namespace SABenefits
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
