using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMS.Test.Startup))]
namespace CMS.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
