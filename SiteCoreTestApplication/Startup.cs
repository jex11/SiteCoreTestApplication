using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SiteCoreTestApplication.Models;

[assembly: OwinStartupAttribute(typeof(SiteCoreTestApplication.Startup))]
namespace SiteCoreTestApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }      
    }
}
