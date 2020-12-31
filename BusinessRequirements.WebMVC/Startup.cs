using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessRequirements.WebMVC.Startup))]
namespace BusinessRequirements.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
